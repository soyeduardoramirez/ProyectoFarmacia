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
    public class Empleados : IEmpleados

    {
        public async Task<List<EmpleadosResponse>> ListadoEmpleados()
        {
            List<EmpleadosResponse> Resultado = new List<EmpleadosResponse>();

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

                var lectura = await sqlCommand.ExecuteReaderAsync();
                if (lectura.HasRows)
                {
                    while (lectura.Read())
                    {
                        Resultado.Add(
                            new Models.EmpleadosResponse()
                            {
                                idempleado = lectura.GetInt32(0),
                                idrol = lectura.GetInt32(1),
                                nombre_empleado = lectura.GetString(2),
                                apellido_empleado = lectura.GetString(3),
                                direccion = lectura.GetString(4),
                                telefono = lectura.GetString(5),
                                email = lectura.GetString(6),
                                puesto = lectura.GetString(7),
                                contrasena = lectura.GetString(8)
                            });
                    }
                }

                conexion.Close();
                return Resultado;
            }
        }
        public async Task<SimpleResponse> AgregarEmpleados(EmpleadosResponse empleadosResponse)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpers.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[Sp_Empleados]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "AgregarEmpleado");
                sqlCommand.Parameters.AddWithValue("@nombre_empleado", empleadosResponse.nombre_empleado);
                sqlCommand.Parameters.AddWithValue("@apellido_empleado", empleadosResponse.apellido_empleado);
                sqlCommand.Parameters.AddWithValue("@direccion", empleadosResponse.direccion);
                sqlCommand.Parameters.AddWithValue("@telefono", empleadosResponse.telefono);
                sqlCommand.Parameters.AddWithValue("@email", empleadosResponse.email);
                sqlCommand.Parameters.AddWithValue("@puesto", empleadosResponse.puesto);
                sqlCommand.Parameters.AddWithValue("@idrol", empleadosResponse.idrol);
                sqlCommand.Parameters.AddWithValue("@contrasena", empleadosResponse.contrasena);
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
                        Resultado.exito = 0;
                        Resultado.mensaje = "";
                    }
                }

                conexion.Close();

                Resultado.exito = (int)exito.Value;
                Resultado.mensaje = msg.Value.ToString();

                return Resultado;

            }
        }
        public async Task<SimpleResponse> ActualizarEmpleados(int idempleado, EmpleadosResponse empleadosResponse)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpers.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[Sp_Empleados]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "ActualizarEmpleado");
                sqlCommand.Parameters.AddWithValue("@idempleado", empleadosResponse.idempleado);
                sqlCommand.Parameters.AddWithValue("@idrol", empleadosResponse.idrol);
                sqlCommand.Parameters.AddWithValue("@nombre_empleado", empleadosResponse.nombre_empleado);
                sqlCommand.Parameters.AddWithValue("@apellido_empleado", empleadosResponse.apellido_empleado);
                sqlCommand.Parameters.AddWithValue("@direccion", empleadosResponse.direccion);
                sqlCommand.Parameters.AddWithValue("@telefono", empleadosResponse.telefono);
                sqlCommand.Parameters.AddWithValue("@email", empleadosResponse.email);
                sqlCommand.Parameters.AddWithValue("@puesto", empleadosResponse.puesto);
                sqlCommand.Parameters.AddWithValue("@contrasena", empleadosResponse.contrasena);
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
                        Resultado.exito = 0;
                        Resultado.mensaje = "";


                    }
                }

                conexion.Close();
                Resultado.exito = (int)exito.Value;
                Resultado.mensaje = msg.Value.ToString();

                return Resultado;

            }
        }
        public async Task<SimpleResponse> EliminarEmpleados(int idempleado)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpers.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[Sp_Empleados]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "EliminarEmpleado");
                sqlCommand.Parameters.AddWithValue("@idempleado", idempleado);

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
                        Resultado.exito = 0;
                        Resultado.mensaje = "";
                    }
                }

                conexion.Close();
                Resultado.exito = (int)exito.Value;
                Resultado.mensaje = msg.Value.ToString();

                return Resultado;

            }
        }
    }
}