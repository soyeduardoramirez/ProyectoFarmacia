using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEFAC.Core.Models
{
    public class InventariosResponse : SimpleResponse
    {
        public int idinventario { get; set; }
        public int idproducto{ get; set; }
        public int idsucursal { get; set; }
        public int stock { get; set; }
        public string nombre_producto { get; set; }
        public string nombre_sucursal { get; set; }
    }
}