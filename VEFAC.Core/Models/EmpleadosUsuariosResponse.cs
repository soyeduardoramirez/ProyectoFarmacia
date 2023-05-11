using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEFAC.Core.Models
{
    public class EmpleadosUsuariosResponse
    {
        public int idempleado { get; set; }
        public string idusuario { get; set; }
        public string nombre_empleado { get; set; }
        public string apellido_empleado { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string puesto { get; set; }
    }
}
