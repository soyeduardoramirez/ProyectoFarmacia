using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEFAC.Core.Models;

namespace VEFAC.Core.BL.Interfaces
{
    public interface IEmpleados
    {
        Task<List<EmpleadosResponse>> ListadoEmpleados();
        Task<SimpleResponse> AgregarEmpleados(EmpleadosResponse empleadosResponse);
        Task<SimpleResponse> ActualizarEmpleados(int idempleado, EmpleadosResponse empleadosResponse);
        Task<SimpleResponse> EliminarEmpleados(int idempleado);
    }
}