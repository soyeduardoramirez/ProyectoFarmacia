using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEFAC.Core.Models;

namespace VEFAC.Core.BL.Interfaces
{
    public interface IVentas
    {
        Task<List<VentasResponse>> ListadoVentas();
        Task<SimpleResponse> AgregarVentas(VentasResponse ventasResponse);
        Task<SimpleResponse> ActualizarVentas(int idventa, VentasResponse ventasResponse);
        Task<SimpleResponse> EliminarVentas(int idventa);
    }
}
