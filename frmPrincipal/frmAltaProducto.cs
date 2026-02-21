using dominio;
using dominio.enums;
using service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;

namespace frmPrincipal
{
    public partial class frmAltaProducto : Form
    {
        Producto producto = null;
        OpenFileDialog archivo = null;
        public frmAltaProducto()
        {
            InitializeComponent();
        }
        public frmAltaProducto(Producto producto)
        {
            InitializeComponent();
            this.producto = producto;
            Text = "Modificar producto";
        }

        private void frmAltaProducto_Load(object sender, EventArgs e)
        {
            CategoriaService categoriaService = new CategoriaService();
            MarcaService marcaService = new MarcaService();

            try
            {
                //Cargamos la lista de categorías
                cboCategoria.DataSource = categoriaService.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                //Cargamos la lista de marcas
                cboMarca.DataSource = marcaService.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";


                if (producto != null)
                {
                    //Si producto no es null precargamos los datos en los textbox
                    cargarTextBox();
                    txbDescripcion.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    //Si es null, solo establecemos por defecto la categoria varios
                    cboCategoria.SelectedIndex = -1;
                    cboMarca.SelectedIndex = -1;
                    //cboTipoVenta.Text = "Unidad";
                    txbDescripcion.ForeColor = System.Drawing.Color.DimGray;
                    //txbDescripcion.Text = "Peso, cant. unidades, sabor, etc...";

                }
                Helper.cargarImg(pbxAlta, txbUrlImagen.Text);
                txbCodigo.Focus();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            ProductoService productoService = new ProductoService();

            try
            {
                if (producto == null) //Si es nulo, quiere decir que estamos AGREGANDO
                {
                    producto = new Producto();
                }
                else // Si no es nulo, estamos MODIFICANDO. Entonces tomamos el id precargado en el textbox
                {
                    producto.Id = int.Parse(txbId.Text);
                }

                //if (txbCodBarras.Text.Length == 0)
                //    throw new ArgumentException("El código de barras no puede estar vacío");

                if (!validarTodo())
                {
                    //MessageBox.Show("Los campos de Código de barras, Precio y Stock deben contener solo números.");
                    if (producto.Id == 0)
                        producto = null;
                    return;
                }
                

                

                producto.Cod = txbCodigo.Text;

                producto.Nombre = txbNombre.Text;

                producto.Descripcion = txbDescripcion.Text;
                //La categoría se obtiene del índice seleccionado en el comboBox
                producto.Categoria = (Categoria)cboCategoria.SelectedItem;
                producto.Marca = (Marca)cboMarca.SelectedItem;

                //Los precios y el stock se validan en los KeyPress
                //if (Helper.validarTxbNumericos(txbPrecioKiosco))
                producto.Precio = decimal.Parse(txbPrecio.Text);

                //if (Helper.validarTxbNumericos(txbPrecioKiosco))

                if (archivo != null && !(txbUrlImagen.Text.ToLower().Contains("http")))
                {
                    if (!guardarImagenLocal())
                        return;
                }
                else if (txbUrlImagen.Text.ToLower().Contains("http"))
                {
                    if (!guardarImagenWeb())
                        return;
                }
                else
                {
                    if (txbUrlImagen.Text.Trim().Length == 0)
                        producto.ImagenUrl = null;
                    else
                        producto.ImagenUrl = txbUrlImagen.Text;
                    //if (txbUrlImagen.Text.Length != 0)
                    //    producto.ImagenUrl = txbUrlImagen.Text;
                }


                if (producto.Id == 0) // id== 0 significa producto nuevo
                {
                    productoService.agregar(producto);
                    MessageBox.Show("Producto agregado exitosamente.", "Alta de producto");
                }
                else
                {
                    productoService.modificar(producto);
                    MessageBox.Show("Producto modificado exitosamente.", "Modificación");
                }

                DialogResult = DialogResult.OK;
                Close();



            }
            catch (ArgumentException ae)
            {
                if (producto.Id == 0)
                    producto = null;
                MessageBox.Show(ae.Message);
            }
            catch (Exception ex)
            {
                //Si el id == 0, estábamos agregando un producto, entonces 'reseteamos' el producto
                //Si id !=0 quiere decir que estábamos modificando, entonces no lo 'reseteamos'
                if (producto.Id == 0)
                    producto = null;
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnAgregarImg_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tif;*.tiff;*.webp";

            if (archivo.ShowDialog() == DialogResult.OK)
            {

                txbUrlImagen.Text = archivo.FileName;
                Helper.cargarImg(pbxAlta, archivo.FileName);
            }
        }
        private void btnLimpiarImagen_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar la imagen?", "Eliminar imagen", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                txbUrlImagen.Clear();
                producto.ImagenUrl = null;
                Helper.cargarImg(pbxAlta, "");
            }
        }

        private void txbCodigo_Leave(object sender, EventArgs e)
        {
            if (producto == null)
            {
                try
                {
                    ProductoService productoService = new ProductoService();
                    producto = productoService.buscarCodigo(txbCodigo.Text);
                    if (producto != null)
                    {
                        string cadenaProd = producto.Cod + " \"" + producto.Nombre + " " + producto.Descripcion;
                        DialogResult resultado = MessageBox.Show("El producto con Codigo: " + cadenaProd + "\" ya existe.\n" +
                            "¿Desea modificarlo?", "Producto existente", MessageBoxButtons.YesNo);

                        if (resultado == DialogResult.Yes)
                        {
                            cargarTextBox();
                            txbCodigo.ReadOnly = true;
                        }
                        else
                        {
                            txbCodigo.Clear();
                            MessageBox.Show("El Codigo ya existe. Intente con otro o elimine definitivamente el producto.");
                            producto = null;
                            txbCodigo.Focus();
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void cargarTextBox()
        {
            txbId.Text = producto.Id.ToString();
            txbCodigo.Text = producto.Cod;
            txbNombre.Text = producto.Nombre;
            txbDescripcion.Text = producto.Descripcion;
            cboCategoria.SelectedItem = producto.Categoria;
            txbPrecio.Text = producto.Precio.ToString("F2");
            txbUrlImagen.Text = producto.ImagenUrl;
        }


        private bool guardarImagenLocal()
        {
            if (archivo == null) return true;

            string carpeta = ConfigurationManager.AppSettings["images-folder"];
            string nombreArchivo = archivo.SafeFileName;
            string carpetaArchivo = Path.GetDirectoryName(archivo.FileName) + "\\";
            string rutaAchivoNuevo = Path.Combine(carpeta, nombreArchivo);


            if (File.Exists(rutaAchivoNuevo))// Comprobamos si hay un archivo con ese nombre en esa ruta
            {
                if (rutaAchivoNuevo.Equals(producto.ImagenUrl)) return true;

                //Si el archivo seleccionado ya se encuentra dentro de la carpeta de recursos, no lo copia,
                //solamente cambia la url
                if (carpetaArchivo.Equals(carpeta))
                {
                    producto.ImagenUrl = rutaAchivoNuevo;
                    return true;
                }

                DialogResult respuesta = MessageBox.Show("Ya existe una imagen con ese nombre. ¿Desea sobrescribirla?", "Imagen existente", MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    try
                    {
                        if (pbxAlta.Image != null)
                        {
                            pbxAlta.Image.Dispose(); // Liberamos el recurso de la imagen para poder sobrescribirla
                            pbxAlta.Image = null;
                        }
                        pbxAlta.ImageLocation = null;

                        File.Copy(archivo.FileName, rutaAchivoNuevo, true);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Error al sobreescribir: " + ex.ToString());
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            else //el archivo no existe
            {
                try
                {
                    if (!System.IO.Directory.Exists(carpeta))
                        System.IO.Directory.CreateDirectory(carpeta);

                    File.Copy(archivo.FileName, rutaAchivoNuevo);

                }
                catch (Exception ex)
                {

                    MessageBox.Show("El archivo no se pudo guardar: " + ex.ToString());
                }
            }
            producto.ImagenUrl = rutaAchivoNuevo;
            return true;
        }
        private bool guardarImagenWeb()
        {
            //URL
            Uri uri = new Uri(txbUrlImagen.Text);
            string rutaLimpia = uri.AbsolutePath;

            //Carpeta destino
            string carpetaDestino = ConfigurationManager.AppSettings["images-folder"];
            string directorioBase = AppDomain.CurrentDomain.BaseDirectory;
            string rutaCompleta = Path.Combine(directorioBase, carpetaDestino);

            //Nos aseguramos que la carpeta exista
            if (!Directory.Exists(rutaCompleta)) Directory.CreateDirectory(rutaCompleta);

            //Nombre archivo
            string extension = Path.GetExtension(rutaLimpia);
            string nombreArchivo = Helper.limpiarCaracteresEspeciales(txbCodigo.Text) +Helper.limpiarCaracteresEspeciales(txbNombre.Text)+ DateTime.Now.ToString("dd-MM-yy-HH-mm-ss") + extension;

            //Ruta destino
            string rutaDestino = Path.Combine(rutaCompleta, nombreArchivo);

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;
                HttpClientHandler handler = new HttpClientHandler();
                handler.AllowAutoRedirect = true;
                handler.UseCookies = true;

                using (HttpClient cliente = new HttpClient(handler))
                {
                    byte[] imagenBytes = cliente.GetByteArrayAsync(uri).Result;

                    File.WriteAllBytes(rutaDestino, imagenBytes);
                    producto.ImagenUrl = rutaDestino;
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo descargar la imagen: " + ex.ToString());
                return false;
            }


        }
        private bool validarTodo()
        {
            if (!Helper.validarNomDesc(txbCodigo) || !Helper.validarCaracteresEspeciales(txbCodigo))
                return false;
            if (txbCodigo.Text.Length > 13)
            {
                if (producto.Id == 0)
                    producto = null;
                MessageBox.Show("El código no puede tener más de 13 dígitos.");
                return false;
            }

            if (!Helper.validarNomDesc(txbNombre) || !Helper.validarCaracteresEspeciales(txbNombre))
                return false;
            
            if (cboMarca.SelectedIndex == -1)
            {
                //if (producto.Id == 0)
                //    producto = null;
                MessageBox.Show("Por favor seleccione la marca.");
                return false;
            }

            if (!Helper.validarNomDesc(txbDescripcion) || !Helper.validarCaracteresEspeciales(txbDescripcion))
                return false;

            if (cboCategoria.SelectedIndex == -1)
            {
                //if (producto.Id == 0)
                //    producto = null;
                MessageBox.Show("Por favor seleccione la categoría.");
                return false;
            }

            if (!Helper.validarTxbNumericos(txbPrecio, false))
                return false;
            return true;
        }

        private void txbUrlImagen_TextChanged(object sender, EventArgs e)
        {
            Helper.cargarImg(pbxAlta, txbUrlImagen.Text);
        }
        private void txbDescripcion_Enter(object sender, EventArgs e)
        {
            if (txbDescripcion.Text.Equals("Peso, cant. unidades, sabor, etc..."))
                txbDescripcion.Text = "";
            txbDescripcion.ForeColor = System.Drawing.Color.Black;
        }

        private void txbCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.manejarCaracteresEspeciales(e);
        }

        private void txbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.soloDecimal(e, txbPrecio);
        }
    }
}
