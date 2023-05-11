using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEFAC.Core.Models
{
    public class ProductosConsultaResponse
    {
        public int idproducto { get; set; }
        public int idcategoria { get; set; }
        public int idmarca { get; set; }
        public string nombre_producto { get; set; }
        public decimal precio { get; set; }
        public string imagen { get; set; }
        public string nombrecategoria { get; set; }
        public string nombremarca { get; set; }
    }
}
