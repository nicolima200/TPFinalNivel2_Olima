using System;
using dominio;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service
{
    public class CaratulaService
    {
        public CaratulaService() { }

        public List<Caratula> listarCaratulas()
        {
            List<Caratula> caratulas = new List<Caratula>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setProcAlmacenado("spCaratulas");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Caratula aux = new Caratula();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

                    
                    aux.CodigoPenal = datos.Lector["CodigoPenal"].ToString();
                    aux.Estado = (bool)datos.Lector["Estado"];

                    caratulas.Add(aux);
                }
                return caratulas;
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

        public Caratula obtenerCaratulaPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setProcAlmacenado("");
            }
            catch (Exception)
            {

                throw;
            }

            return null;
        }
    }
}
