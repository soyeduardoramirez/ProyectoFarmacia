using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEFAC.Core.Models
{
    public class LoginResponse 
    {
        public string email { get; set; }
        public string contrasena { get; set; }
        public string rol { get; set; }
        public int id { get; set; }
    }
}
