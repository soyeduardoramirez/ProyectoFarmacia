using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEFAC.Core.Models;

namespace VEFAC.Core.BL.Interfaces
{
    public interface IProveedores
    {
        Task<List<ProveedoresResponse>> ListadoProveedores();
        Task<SimpleResponse> AgregarProveedores(ProveedoresResponse proveedoresResponse);
        Task<SimpleResponse> ActualizarProveedores(int idproveedor, ProveedoresResponse proveedoresResponse);
        Task<SimpleResponse> EliminarProveedores(int idproveedor);
    }
}
