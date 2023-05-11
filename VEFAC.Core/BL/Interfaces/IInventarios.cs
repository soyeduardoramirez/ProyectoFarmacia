using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEFAC.Core.Models;

namespace VEFAC.Core.BL.Interfaces
{
    public interface IInventarios
    {
        Task<List<InventariosResponse>> ListadoInventarios();
        Task<SimpleResponse> AgregarInventarios(InventariosResponse inventariosResponse);
        Task<SimpleResponse> ActualizarInventarios(int idinventario, InventariosResponse inventariosResponse);
        Task<SimpleResponse> EliminarInventarios(int idinventario);
    }
}