using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEFAC.Core.Models
{
    public class UsuariosResponse : SimpleResponse
    {
        public int idusuario { get; set; }
        public int idrol { get; set; }
        public char nombre_usuario { get; set; }
        public char contrasena { get; set; }
    }
}