using dominio;
using dominio.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace service
{
    public class ProductoService
    {

        public BindingList<Producto> listar()
        {
            BindingList<Producto> listaProductos = new BindingList<Producto>();
            AccesoDatos datos = new AccesoDatos();

            datos.setConsulta(consulta.SqlListar);

            try
            {
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    listaProductos.Add(getProductosLector(datos));
                }

                return listaProductos;
            }
            catch (Exception ex)
            {
               throw new Exception("ERROR AL LISTAR!: "+ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Producto producto)
        {
            AccesoDatos datos= new AccesoDatos();
            try
            {
                datos.setConsulta(consulta.SqlAlta);
                setearParametros(datos,producto);

                datos.ejecutarAccion();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion(); 
            }
        }

        public void modificar(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta(consulta.SqlActualizar);
                datos.setParametro("@id", producto.Id);
                setearParametros( datos,producto);

                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally {datos.cerrarConexion();}
        }

        public void eliminarFisico(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta(consulta.SqlEliminarDefinitivo);
                datos.setParametro("@id", id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public Producto buscarCodigo(string codigo)
        {
            AccesoDatos datos= new AccesoDatos();
            datos.setConsulta(consulta.SqlBuscarCadena);
            datos.setParametro("@campo", "Codigo");
            datos.setParametro("@cadena", codigo);
            try
            {
                datos.ejecutarConsulta();
                if (datos.Lector.Read())
                {    
                   return getProductosLector(datos);                
                }
                return null;                
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR AL BUSCAR!: "+ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public BindingList<Producto> buscarCadena(string campo,string cadena)
        {
            BindingList<Producto> listaEncontrados = new BindingList<Producto>();
            AccesoDatos datos= new AccesoDatos();
            datos.setConsulta(consulta.SqlBuscarCadena);
            datos.setParametro("@campo", campo);
            datos.setParametro("@cadena", cadena);

            try
            {
                datos.ejecutarConsulta();
                while (datos.Lector.Read())
                {    
                   listaEncontrados.Add(getProductosLector(datos));
                }
                return listaEncontrados;                
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR AL BUSCAR!: "+ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Producto getProductosLector(AccesoDatos datos)
        {
            // sqlListarActivos = "SELECT id,codBarras, nombre, descripcion, categoria,
            // precioMayorista, precioKiosco, stock, stockMinimo, activo, urlImagen,
            // ventaPorFraccion FROM productos where activo=1"
            Producto producto = new Producto();

            producto.Id = datos.Lector.GetInt32(0);
            producto.Cod = (string)datos.Lector["Codigo"];
            producto.Nombre = (string)datos.Lector["Nombre"];
            producto.Descripcion = (string)datos.Lector["Descripcion"];


            producto.Marca=new Marca();
            producto.Marca.Id = datos.Lector.GetInt32(4);
            producto.Marca.Descripcion = (string)datos.Lector["Marca"];

            producto.Categoria = new Categoria();
            producto.Categoria.Id = datos.Lector.GetInt32(6);
            producto.Categoria.Descripcion = (string)datos.Lector["Categoria"];

            if (!(datos.Lector.IsDBNull(8)))
                producto.ImagenUrl = (string)datos.Lector["ImagenUrl"];
            producto.Precio = datos.Lector.GetDecimal(9);

            return producto;
        }

        private void setearParametros(AccesoDatos datos, Producto producto)
        {
            datos.setParametro("@cod", producto.Cod);
            datos.setParametro("@nom", producto.Nombre);
            datos.setParametro("@desc", producto.Descripcion);
            datos.setParametro("@id_mar", producto.Marca.Id);
            datos.setParametro("@id_cat", producto.Categoria.Id);
            datos.setParametro("@precio", producto.Precio);
            if (producto.ImagenUrl == null)
                datos.setParametro("@url", DBNull.Value);
            else
                datos.setParametro("@url", producto.ImagenUrl);
            
        }

    }
}
