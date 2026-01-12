using dominio;
using dominio.enums;
using service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace frmPrincipal
{
    public partial class frmProductos : Form
    {
        private BindingList<Producto> listaProductos;
        private bool modoRecuperar = false;
        private Producto seleccionado = null;
        public frmProductos()
        {
            InitializeComponent();
            this.modoRecuperar = false;
        }

        public frmProductos(bool modoRecuperar)
        {
            InitializeComponent();
            this.modoRecuperar = modoRecuperar;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.Text = "Gestor Inventario || Fecha: " + DateTime.Now.ToShortDateString();

            cboCampo.DataSource = Enum.GetValues(typeof(dominio.enums.CampoBusqueda));
            cboCampo.SelectedIndex = -1;

            cboCriterio.SelectedIndex = -1;


            cargar();

        }

        private void cargar(bool activo = true)
        {
            try
            {

                ProductoService productoService = new ProductoService();
                listaProductos = new BindingList<Producto>();
                if (activo)
                    listaProductos = productoService.listar();
                else
                    listaProductos = productoService.listar(false);

                dgvPrincipal.DataSource = listaProductos;
                dgvPrincipal.Columns["Precio"].DefaultCellStyle.Format = "F2";
                dgvPrincipal.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ocultarMostrarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ocultarMostrarColumnas(bool visibles = false)
        {
            dgvPrincipal.Columns["ID"].Visible = visibles;
            dgvPrincipal.Columns["ImagenUrl"].Visible = visibles;
            dgvPrincipal.RowHeadersVisible = visibles;
        }

        private void dgvPrincipal_SelectionChanged(object sender, EventArgs e)
        {
            cargarImagen();
            seleccionado = productoSeleccionado();
            cargarDetalle();
        }

        private Producto productoSeleccionado()
        {
            Producto productoSeleccionado = null;
            if (dgvPrincipal.CurrentRow != null)
            {
                return productoSeleccionado = (Producto)dgvPrincipal.CurrentRow.DataBoundItem;
            }
            return productoSeleccionado;
        }

        //CARGAR/LIMPIAR IMAGEN Y DETALLE:
        private void cargarImagen()
        {
            if (productoSeleccionado() != null)
            {
                Helper.cargarImg(pbxProducto, productoSeleccionado().ImagenUrl);
            }
        }
        private void cargarDetalle()
        {
            Producto productoSeleccionado;
            if (dgvPrincipal.CurrentRow.DataBoundItem != null)
            {
                productoSeleccionado = (Producto)dgvPrincipal.CurrentRow.DataBoundItem;
                lblNombre.Text = productoSeleccionado.Nombre;
                lblDescripcion.Text = productoSeleccionado.Descripcion;
                lblPrecioNro.Text = "$ " + productoSeleccionado.Precio.ToString("F2");
            }
            else
            {
                limpiarLabelsDetalle();
            }
        }
        private void limpiarLabelsDetalle()
        {
            lblNombre.Text = "";
            lblDescripcion.Text = "";
            lblPrecioTexto.Text = "";
            lblPrecioNro.Text = "";

        }
        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            tbxFiltro.Clear();
        }
        /****/
        private void tbxFiltro_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxFiltro.Text))
            {
                dgvPrincipal.DataSource = null;
                dgvPrincipal.DataSource = listaProductos;
                //DgvPrincipal.CurrentCell = DgvPrincipal.Rows[0].Cells[1];
            }

            if (tbxFiltro.Text.Length > 0)
            {
                //Casteamos la BindingList a List para poder usar el método FindAll
                List<Producto> listaTemp = listaProductos.ToList();
                string filtro = tbxFiltro.Text.ToLower();

                //Aplicamos el filtro y volvemos a castear a BindingList
                BindingList<Producto> listaFiltrada = new BindingList<Producto>(listaTemp.FindAll(x => x.Nombre.ToLower().Contains(filtro) || x.Descripcion.ToLower().Contains(filtro) || x.Marca.Descripcion.ToLower().Contains(filtro) || x.Categoria.Descripcion.ToLower().Contains(filtro)));
                //List<Producto>listaFiltrada = listaTemp.FindAll(x => x.Nombre.ToLower().Contains(filtro) || x.Descripcion.ToLower().Contains(filtro) || x.Marca.Descripcion.ToLower().Contains(filtro) || x.Categoria.Descripcion.ToLower().Contains(filtro));
                dgvPrincipal.DataSource = listaFiltrada;


            }
            if (dgvPrincipal.Rows.Count > 0)
            {
                dgvPrincipal.CurrentCell = dgvPrincipal.Rows[0].Cells[1];
                dgvPrincipal.Rows[0].Selected = true;
                Producto prueba = (Producto)dgvPrincipal.CurrentRow.DataBoundItem;
            }
            else
            {
                dgvPrincipal.ClearSelection();
                Helper.cargarImg(pbxProducto, "");
                limpiarLabelsDetalle();
            }
            ocultarMostrarColumnas();
        }

        /****/

        //GESTIÓN DE PRODUCTOS:
        private void agregarProducto()
        {
            frmAltaProducto altaProducto = new frmAltaProducto();
            DialogResult resultado = altaProducto.ShowDialog();

            if (resultado == DialogResult.OK)
                cargar();
        }
        private void modificarProducto()
        {
            Producto productoSeleccionado;
            if (dgvPrincipal.CurrentRow != null)
                productoSeleccionado = (Producto)dgvPrincipal.CurrentRow.DataBoundItem;
            else
                return;

            frmAltaProducto modificarProducto = new frmAltaProducto(productoSeleccionado);
            DialogResult resultado = modificarProducto.ShowDialog();

            if (resultado == DialogResult.OK)
                cargar();
        }
        private void eliminarDefinitivo()
        {
            ProductoService productoService = new ProductoService();
            Producto productoSeleccionado;

            try
            {
                if (dgvPrincipal.CurrentRow != null)
                    productoSeleccionado = dgvPrincipal.CurrentRow.DataBoundItem as Producto;
                else
                    return;

                string cadena = "¿Está seguro que desea ELIMINAR DEFINITIVAMENTE el producto " + productoSeleccionado.Nombre + " " + productoSeleccionado.Descripcion + " ?"
                    + "\n¡NO PODRÁ RECUPERAR EL PRODUCTO!";

                DialogResult resultado = MessageBox.Show(cadena, "ADVERTENCIA: ELIMINACIÓN DEFINITIVA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    productoService.eliminarFisico(productoSeleccionado.Id);
                    cargar(false);
                }
                if (dgvPrincipal.Rows.Count == 0)
                {
                    dgvPrincipal.ClearSelection();
                    Helper.cargarImg(pbxProducto, "");
                    limpiarLabelsDetalle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /***/

        //METODOS DEL MENÚ:
        private void eliminarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eliminarDefinitivo();
        }

        private void agregarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agregarProducto();
        }

        private void modificarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modificarProducto();
        }

        private void frmProductos_Shown(object sender, EventArgs e)
        {
            tbxFiltro.Focus();
        }

        private void btnBusquedaAvanzada_Click(object sender, EventArgs e)
        {
            if (cboCampo.SelectedIndex == -1 || cboCriterio.SelectedIndex ==-1)
            {
                MessageBox.Show("Debe seleccionar un campo para la búsqueda avanzada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            BindingList<Producto> listaFiltrada = new BindingList<Producto>();
            ProductoService productoService = new ProductoService();

            if ((CampoBusqueda)cboCampo.SelectedItem == CampoBusqueda.Precio)
            {

            }
            else
            {
                string cadena = obtenerCadena(cboCriterio.SelectedItem, tbxBusquedaAvanzada.Text);

                listaFiltrada = productoService.buscarCadena(cboCampo.SelectedItem.ToString(), tbxBusquedaAvanzada.Text.Trim());
            }


            dgvPrincipal.DataSource = listaFiltrada;
        }

        private string obtenerCadena(object selectedItem, string cadena)
        {
            if ((CriterioTexto)selectedItem == CriterioTexto.ComienzaCon)
            {
                return cadena + "%";
            }
            else if ((CriterioTexto)selectedItem == CriterioTexto.TerminaCon)
            {
                return "%" + cadena;
            }
            else //Contiene
            {
                return "%" + cadena + "%";
            }
        }

        private void cboCampo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tbxBusquedaAvanzada.Clear();
            if (cboCampo.SelectedIndex != -1)
            {
                if ((CampoBusqueda)cboCampo.SelectedItem == CampoBusqueda.Precio)
                {
                    cboCriterio.DataSource = Enum.GetValues(typeof(dominio.enums.CriterioPrecio));
                }
                else
                {
                    cboCriterio.DataSource = Enum.GetValues(typeof(dominio.enums.CriterioTexto));
                }
            }
        }

        private void tbxBusquedaAvanzada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cboCampo.SelectedIndex != -1)
            {
                if ((CampoBusqueda)cboCampo.SelectedItem == CampoBusqueda.Precio)
                    Helper.soloDecimal(e, tbxBusquedaAvanzada);

            }
        }
    }
}
