using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEFAC.Core.Models
{
    public class ComprasResponse : SimpleResponse
    {
        public int idcompra { get; set; }
        public int idempleado { get; set; }
        public int idproveedor { get; set; }
        public int idproducto { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha { get; set; }
    }
}