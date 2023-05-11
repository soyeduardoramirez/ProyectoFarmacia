using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEFAC.Core.Models;

namespace VEFAC.Core.BL.Interfaces
{
    public interface IClientes
    {
        Task<List<ClientesResponse>> ListadoClientes();
        Task<SimpleResponse> AgregarClientes(ClientesResponse clientesResponse);
        Task<SimpleResponse> ActualizarClientes(int idcliente, ClientesResponse clientesResponse);
        Task<SimpleResponse> EliminarClientes(int idcliente);
    }
}