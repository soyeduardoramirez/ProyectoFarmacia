using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEFAC.Core.Models
{
    public class VentasResponse : SimpleResponse
    {
        public int idventa { get; set; }
        public int idempleado { get; set; }
        public int idcliente { get; set; }
        public int idproducto { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha { get; set; }
        public decimal subtotal { get; set; }
        public int impuestos { get; set; }
        public decimal total { get; set; }

        //consulta 
        public string nombre_empleado { get; set; }
        public string apellido_empleado { get; set; }
        public string nombre_cliente { get; set; }
        public string apellido_cliente { get; set; }
        public string nombre_producto { get; set; }
    }
}
