using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEFAC.Core.Models
{
    public class CategoriasResponse : SimpleResponse
    {
        public int idcategoria { get; set; }
        public string nombre_categoria{ get; set; }
    }
}