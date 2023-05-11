using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEFAC.Core.Models;

namespace VEFAC.Core.BL.Interfaces
{
    public interface IUsuarios
    {
        Task<List<UsuariosResponse>> ListadoUsuarios();
        Task<SimpleResponse> AgregarUsuarios(UsuariosResponse usuariosResponse);
        Task<SimpleResponse> ActualizarUsuarios(int idusuario, UsuariosResponse usuariosResponse);
        Task<SimpleResponse> EliminarUsuarios(int idusuario);
    }
}