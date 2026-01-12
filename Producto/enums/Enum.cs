using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio.enums
{
    public enum CampoBusqueda
    {
        Nombre,
        Codigo,
        Categoria,
        Precio
    }

    public enum CriterioTexto
    {
        ComienzaCon,
        TerminaCon,
        Contiene
    }

    public enum CriterioPrecio
    {
        MayorQue,
        MenorQue,
        IgualA
    }
}
