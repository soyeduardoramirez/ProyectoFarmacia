using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEFAC.Core.Models;

namespace VEFAC.Core.BL.Interfaces
{
    public interface ICompras
    {
        Task<List<ComprasResponse>> ListadoCompras();
        Task<SimpleResponse> AgregarCompras(ComprasResponse comprasResponse);
        Task<SimpleResponse> ActualizarCompras(int idcompra, ComprasResponse comprasResponse);
        Task<SimpleResponse> EliminarCompras(int idcompra);
    }
}
