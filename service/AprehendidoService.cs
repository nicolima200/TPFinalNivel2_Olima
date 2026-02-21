using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service
{
    public class AprehendidoService
    {
        public List<Aprehendido> listarAprehendidos()
        {
            List<Aprehendido> listaAprehendidos = new List<Aprehendido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("SELECT * FROM Aprehendidos");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Aprehendido aux = new Aprehendido();
                    aux.Id = (int)datos.Lector["id"];
                    aux.Caracteristicas = (string)datos.Lector["caracteristicas"];
                    aux.Nombre = (string)datos.Lector["nombre"];
                    aux.Apellido = (string)datos.Lector["apellido"];
                    aux.Dni = (string)datos.Lector["dni"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["fechaNacimiento"];
                    aux.Nacionalidad = (string)datos.Lector["nacionalidad"];
                    aux.Genero = (string)datos.Lector["genero"];
                    aux.Domicilio = (string)datos.Lector["domicilio"];
                    aux.Telefono = (string)datos.Lector["telefono"];
                    aux.Alias = (string)datos.Lector["alias"];

                    listaAprehendidos.Add(aux);
                }

                return listaAprehendidos;
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

        public void agregarAprehendido(Aprehendido aprehendido)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

                try
                {
                    accesoDatos.setConsulta("INSERT INTO Aprehendidos (nombre, apellido, dni, fechaNacimiento, nacionalidad, genero, domicilio, telefono, alias, caracteristicas) VALUES (@nombre, @apellido, @dni, @fechaNacimiento, @nacionalidad, @genero, @domicilio, @telefono, @alias, @caracteristicas)");
                    accesoDatos.setParametro("@nombre", aprehendido.Nombre);
                    accesoDatos.setParametro("@apellido", aprehendido.Apellido);
                    accesoDatos.setParametro("@dni", aprehendido.Dni);
                    accesoDatos.setParametro("@fechaNacimiento", aprehendido.FechaNacimiento);
                    accesoDatos.setParametro("@nacionalidad", aprehendido.Nacionalidad);
                    accesoDatos.setParametro("@genero", aprehendido.Genero);
                    accesoDatos.setParametro("@domicilio", aprehendido.Domicilio);
                    accesoDatos.setParametro("@telefono", aprehendido.Telefono);
                    accesoDatos.setParametro("@alias", aprehendido.Alias);
                    accesoDatos.setParametro("@caracteristicas", aprehendido.Caracteristicas);
    
                    accesoDatos.ejecutarAccion();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    accesoDatos.cerrarConexion();
            }

        }
    }
}
