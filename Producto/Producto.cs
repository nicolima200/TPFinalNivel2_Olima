using System.ComponentModel;
using dominio.enums;    

namespace dominio
{
    public class Producto
    {

        public int Id { get; set; }
        [DisplayName("Código")]
        public string Cod { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public string ImagenUrl { get; set; }
        public decimal Precio { get; set; }
        public Producto() { }

    }
}
