using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEFAC.Core.Models
{
    public class MarcasResponse : SimpleResponse
    {
        public int id_marca { get; set; }
        public string nombre_marca { get; set; }
    }
}
