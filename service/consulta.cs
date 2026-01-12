using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service
{
    public class consulta
    {

    private const string sqlBuscarPrecio= "SELECT A.Id, Codigo, Nombre, A.Descripcion, IdMarca, M.descripcion Marca, IdCategoria, C.descripcion Categoria,ImagenUrl,Precio FROM articulos A, marcas M, categorias C where IdMarca = M.id and IdCategoria = C.id and precio {0} @precio";
    private const string sqlBuscarCadena= "SELECT A.Id, Codigo, Nombre, A.Descripcion, IdMarca, M.descripcion Marca, IdCategoria, C.descripcion Categoria,ImagenUrl,Precio FROM articulos A, marcas M, categorias C where IdMarca = M.id and IdCategoria = C.id and {0} LIKE @cadena";
    private const string sqlBuscarCodigo= "SELECT A.Id, Codigo, Nombre, A.Descripcion, IdMarca, M.descripcion Marca, IdCategoria, C.descripcion Categoria,ImagenUrl,Precio FROM articulos A, marcas M, categorias C where IdMarca = M.id and IdCategoria = C.id and codigo LIKE @cadena";

    private const string sqlAlta = "INSERT INTO ARTICULOS (Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) VALUES (@cod, @nom, @desc, @id_mar, @id_cat,@url,@precio)";
    private const string sqlListar = "SELECT A.Id, Codigo, Nombre, A.Descripcion, IdMarca, M.descripcion Marca, IdCategoria, C.descripcion Categoria,ImagenUrl,Precio FROM articulos A, marcas M, categorias C where IdMarca = M.id and IdCategoria = C.id";
    private const string sqlActualizar = "UPDATE articulos SET Codigo=@cod,nombre=@nom, descripcion=@desc,IdMarca=@id_mar, IdCategoria=@id_cat,precio=@precio, ImagenUrl=@url where id = @id";
    private const string sqlEliminarDefinitivo = "DELETE FROM articulos WHERE id = @id";

        public static string SqlAlta => sqlAlta;

        public static string SqlBuscarCadena => sqlBuscarCadena;

        public static string SqlBuscarPrecio => sqlBuscarPrecio;

        public static string SqlActualizar => sqlActualizar;

        public static string SqlEliminarDefinitivo => sqlEliminarDefinitivo;

        public static string SqlListar => sqlListar;

        public static string SqlBuscarCodigo => sqlBuscarCodigo;
    }
}
