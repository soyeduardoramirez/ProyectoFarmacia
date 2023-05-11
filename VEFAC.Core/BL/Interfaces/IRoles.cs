using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEFAC.Core.Models;

namespace VEFAC.Core.BL.Interfaces
{
    public interface IRoles
    {
        Task<List<RolesResponse>> ListadoRoles();
        Task<SimpleResponse> AgregarRoles(RolesResponse rolesResponse);
        Task<SimpleResponse> ActualizarRoles(int idrol, RolesResponse rolesResponse);
        Task<SimpleResponse> EliminarRoles(int idrol);
    }
}