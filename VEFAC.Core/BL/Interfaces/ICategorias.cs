using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEFAC.Core.Models;

namespace VEFAC.Core.BL.Interfaces
{
    public interface ICategorias
    {
        Task<List<CategoriasResponse>> ListadoCategorias();
        Task<SimpleResponse> AgregarCategorias(CategoriasResponse categoriasResponse);
        Task<SimpleResponse> ActualizarCategorias(int idcategorias, CategoriasResponse categoriasResponse);
        Task<SimpleResponse> EliminarCategorias(int idcategorias);
    }
}