using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEFAC.Core.Models
{
    public class RolesResponse : SimpleResponse
    {
        public int idrol { get; set; }
        public string nombre_rol { get; set; }
    }
}