using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace service
{
    public class ProcedimientoService
    {

        //public BindingList<Producto> listar()
        //{
        //    BindingList<Producto> listaProductos = new BindingList<Producto>();
        //    AccesoDatos datos = new AccesoDatos();

        //    datos.setConsulta(consulta.SqlListar);

        //    try
        //    {
        //        datos.ejecutarConsulta();

        //        while (datos.Lector.Read())
        //        {
        //            listaProductos.Add(getProductosLector(datos));
        //        }

        //        return listaProductos;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("ERROR AL LISTAR!: " + ex.Message);
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}

        public void agregarProcedimiento(Procedimiento procedimiento, List<Aprehendido> listaAprehendidosTemporal)
        {
            SqlConnection conexion = new SqlConnection("server=.\\\\SQLEXPRESS; database=APREHENDIDOS_DB; integrated security=true");
            conexion.Open();

            // Iniciamos la transacción
            SqlTransaction transaccion = conexion.BeginTransaction();

            try
            {
                SqlCommand cmdProc = new SqlCommand("INSERT INTO Procedimientos (turno, descripcion, fechas) OUTPUT INSERTED.Id VALUES (@turno, @descripcion, @fechas)",conexion,transaccion);
                cmdProc.Parameters.AddWithValue("@turno", procedimiento.Turno);
                cmdProc.Parameters.AddWithValue("@descripcion", procedimiento.Descripcion);
                cmdProc.Parameters.AddWithValue("@fecha", procedimiento.Fecha);

                int idProcedimiento = (int)cmdProc.ExecuteScalar();

                foreach (Aprehendido aprehendido in listaAprehendidosTemporal)
                {
                    SqlCommand cmdApre = new SqlCommand("INSERT INTO Aprehendidos (nombre, apellido, dni, fechaNacimiento, nacionalidad, genero, domicilio, telefono, alias, caracteristicas) OUTPUT INSERTED.Id VALUES (@nombre, @apellido, @dni, @fechaNacimiento, @nacionalidad, @genero, @domicilio, @telefono, @alias, @caracteristicas)", conexion, transaccion);
                    cmdApre.Parameters.AddWithValue("@nombre", aprehendido.Nombre);
                    cmdApre.Parameters.AddWithValue("@apellido", aprehendido.Apellido);
                    cmdApre.Parameters.AddWithValue("@dni", aprehendido.Dni);
                    cmdApre.Parameters.AddWithValue("@fechaNacimiento", aprehendido.FechaNacimiento);
                    cmdApre.Parameters.AddWithValue("@nacionalidad", aprehendido.Nacionalidad);
                    cmdApre.Parameters.AddWithValue("@genero", aprehendido.Genero);
                    cmdApre.Parameters.AddWithValue("@domicilio", aprehendido.Domicilio);
                    cmdApre.Parameters.AddWithValue("@telefono", aprehendido.Telefono);
                    cmdApre.Parameters.AddWithValue("@alias", aprehendido.Alias);
                    cmdApre.Parameters.AddWithValue("@caracteristicas", aprehendido.Caracteristicas);

                    int idAprehendido = (int)cmdApre.ExecuteScalar();

                    SqlCommand cmdRelacion = new SqlCommand("INSERT INTO Procedimiento_Aprehendido (idProcedimiento,idAprehendido) VALUES (@idProc, @idApre)",conexion,transaccion);
                    cmdRelacion.Parameters.AddWithValue("@idProc", idProcedimiento);
                    cmdRelacion.Parameters.AddWithValue("@idApre", idAprehendido);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }

        }

        //public void modificar(Producto producto)
        //{
        //    AccesoDatos datos = new AccesoDatos();
        //    try
        //    {
        //        datos.setConsulta(consulta.SqlActualizar);
        //        datos.setParametro("@id", producto.Id);
        //        setearParametros(datos, producto);

        //        datos.ejecutarAccion();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally { datos.cerrarConexion(); }
        //}

        //public void eliminarFisico(int id)
        //{
        //    AccesoDatos datos = new AccesoDatos();
        //    try
        //    {
        //        datos.setConsulta(consulta.SqlEliminarDefinitivo);
        //        datos.setParametro("@id", id);

        //        datos.ejecutarAccion();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally { datos.cerrarConexion(); }
        //}

        //public Producto buscarCodigo(string codigo)
        //{
        //    AccesoDatos datos = new AccesoDatos();
        //    datos.setConsulta(consulta.SqlBuscarCodigo);
        //    datos.setParametro("@cadena", codigo);
        //    Producto productoEncontrado;
        //    try
        //    {
        //        datos.ejecutarConsulta();
        //        if (datos.Lector.Read())
        //        {
        //            productoEncontrado = new Producto();
        //            productoEncontrado = getProductosLector(datos);
        //            return productoEncontrado;
        //        }
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("ERROR AL BUSCAR!: " + ex.Message);
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}
        //public BindingList<Producto> buscarCadena(string campo, string cadena)
        //{
        //    BindingList<Producto> listaEncontrados = new BindingList<Producto>();
        //    AccesoDatos datos = new AccesoDatos();
        //    string consultaConCampo = string.Format(consulta.SqlBuscarCadena, campo);

        //    datos.setConsulta(consultaConCampo);
        //    datos.setParametro("@cadena", cadena);

        //    try
        //    {
        //        datos.ejecutarConsulta();
        //        while (datos.Lector.Read())
        //        {
        //            listaEncontrados.Add(getProductosLector(datos));
        //        }
        //        return listaEncontrados;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("ERROR AL BUSCAR!: " + ex.Message);
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}

        //public BindingList<Producto> buscarPrecio(string operador, decimal precio)
        //{
        //    BindingList<Producto> listaEncontrados = new BindingList<Producto>();
        //    AccesoDatos datos = new AccesoDatos();
        //    string consultaConOperador = string.Format(consulta.SqlBuscarPrecio, operador);

        //    datos.setConsulta(consultaConOperador);
        //    datos.setParametro("@precio", precio);
        //    try
        //    {
        //        datos.ejecutarConsulta();
        //        while (datos.Lector.Read())
        //        {
        //            listaEncontrados.Add(getProductosLector(datos));
        //        }
        //        return listaEncontrados;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("ERROR AL BUSCAR!: " + ex.Message);
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}
        //public Producto getProductosLector(AccesoDatos datos)
        //{
        //    // sqlListarActivos = "SELECT id,codBarras, nombre, descripcion, categoria,
        //    // precioMayorista, precioKiosco, stock, stockMinimo, activo, urlImagen,
        //    // ventaPorFraccion FROM productos where activo=1"
        //    Producto producto = new Producto();

        //    producto.Id = datos.Lector.GetInt32(0);
        //    producto.Cod = (string)datos.Lector["Codigo"];
        //    producto.Nombre = (string)datos.Lector["Nombre"];
        //    producto.Descripcion = (string)datos.Lector["Descripcion"];


        //    producto.Marca = new Marca();
        //    producto.Marca.Id = datos.Lector.GetInt32(4);
        //    producto.Marca.Descripcion = (string)datos.Lector["Marca"];

        //    producto.Categoria = new Categoria();
        //    producto.Categoria.Id = datos.Lector.GetInt32(6);
        //    producto.Categoria.Descripcion = (string)datos.Lector["Categoria"];

        //    if (!(datos.Lector.IsDBNull(8)))
        //        producto.ImagenUrl = (string)datos.Lector["ImagenUrl"];
        //    producto.Precio = datos.Lector.GetDecimal(9);

        //    return producto;
        //}

        //private void setearParametros(AccesoDatos datos, Producto producto)
        //{
        //    datos.setParametro("@cod", producto.Cod);
        //    datos.setParametro("@nom", producto.Nombre);
        //    datos.setParametro("@desc", producto.Descripcion);
        //    datos.setParametro("@id_mar", producto.Marca.Id);
        //    datos.setParametro("@id_cat", producto.Categoria.Id);
        //    datos.setParametro("@precio", producto.Precio);
        //    if (producto.ImagenUrl == null)
        //        datos.setParametro("@url", DBNull.Value);
        //    else
        //        datos.setParametro("@url", producto.ImagenUrl);

        //}

    }
}
