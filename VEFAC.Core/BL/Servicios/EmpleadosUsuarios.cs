using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEFAC.Core.BL.Interfaces;
using VEFAC.Core.Models;

namespace VEFAC.Core.BL.Servicios
{
    public class EmpleadosUsuarios :IEmpleadosUsuarios
    {
        public async Task<List<EmpleadosUsuariosResponse>> ListadoEmpleadosConUsuarios()
        {
            List<EmpleadosUsuariosResponse> Resultado = new List<EmpleadosUsuariosResponse>();

            using (var conexion = new SqlConnection(Helpers.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[Sp_Empleados]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "ListarEmpleados");
                #endregion
                #region Parametros de Salida
                SqlParameter exito = new SqlParameter();
                exito.ParameterName = "@exito";
                exito.SqlDbType = System.Data.SqlDbType.Int;
                exito.Direction = System.Data.ParameterDirection.Output;
                sqlCommand.Parameters.Add(exito);

                SqlParameter msg = new SqlParameter();
                msg.ParameterName = "@mensaje";
                msg.SqlDbType = System.Data.SqlDbType.VarChar;
                msg.Size = 250;
                msg.Direction = System.Data.ParameterDirection.Output;
                sqlCommand.Parameters.Add(msg);

                #endregion
                var lectura = await sqlCommand.ExecuteReaderAsync();
                if (lectura.HasRows)
                {
                    while (lectura.Read())
                    {
                        Resultado.Add(
                            new Models.EmpleadosUsuariosResponse()
                            {
                                idempleado = lectura.GetInt32(0),
                                nombre_empleado = lectura.GetString(1),
                                apellido_empleado = lectura.GetString(2),
                                direccion = lectura.GetString(3),
                                telefono = lectura.GetString(4),
                                email = lectura.GetString(5),
                                puesto = lectura.GetString(6),
                                idusuario = lectura.GetString(7)
                            });
                    }
                }

                conexion.Close();
                return Resultado;
            }
        }
    }
}
