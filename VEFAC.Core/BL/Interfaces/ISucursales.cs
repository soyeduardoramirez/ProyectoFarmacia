using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEFAC.Core.Models;

namespace VEFAC.Core.BL.Interfaces
{
    public interface ISucursales
    {
        Task<List<SucursalesResponse>> ListadoSucursales();
        Task<SimpleResponse> AgregarSucursales(SucursalesResponse sucursalesResponse);
        Task<SimpleResponse> ActualizarSucursales(int idsucursal, SucursalesResponse sucursalesResponse);
        Task<SimpleResponse> EliminarSucursales(int idsucursal);
    }
}