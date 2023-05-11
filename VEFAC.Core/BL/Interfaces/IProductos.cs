using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEFAC.Core.Models;

namespace VEFAC.Core.BL.Interfaces
{
    public interface IProductos
    {
        Task<List<ProductosResponse>> ListadoProductos();
        Task<SimpleResponse> AgregarProductos(ProductosResponse productosResponse);
        Task<SimpleResponse> ActualizarProductos(int idproducto, ProductosResponse productosResponse);
        Task<SimpleResponse> EliminarProductos(int idproducto);
    }
}