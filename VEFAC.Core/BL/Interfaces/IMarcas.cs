using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEFAC.Core.Models;

namespace VEFAC.Core.BL.Interfaces
{
    public interface IMarcas
    {
        Task<List<MarcasResponse>> ListadoMarcas();
        Task<SimpleResponse> AgregarMarca(MarcasResponse marcasResponse);
        Task<SimpleResponse> ActualizarMarca(int id_marca, MarcasResponse marcasResponse);
        Task<SimpleResponse> EliminarMarca(int id_marca);
    }
}
