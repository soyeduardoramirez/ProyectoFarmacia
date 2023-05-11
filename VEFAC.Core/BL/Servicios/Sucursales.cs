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
    public class Sucursales : ISucursales

    {
        public async Task<List<SucursalesResponse>> ListadoSucursales()
        {
            List<SucursalesResponse> Resultado = new List<SucursalesResponse>();

            using (var conexion = new SqlConnection(Helpers.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[Sp_Sucursales]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "ListarSucursales");
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
                            new Models.SucursalesResponse()
                            {
                                idsucursal = lectura.GetInt32(0),
                                nombre_sucursal = lectura.GetString(1),
                                direccion = lectura.GetString(2),
                                telefono = lectura.GetString(3),
                                email = lectura.GetString(4)
                            });
                    }
                }

                conexion.Close();
                return Resultado;
            }
        }
        public async Task<SimpleResponse> AgregarSucursales(SucursalesResponse sucursalesResponse)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpers.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[Sp_Sucursales]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "AgregarSucursal");
                sqlCommand.Parameters.AddWithValue("@nombre_sucursal", sucursalesResponse.nombre_sucursal);
                sqlCommand.Parameters.AddWithValue("@direccion", sucursalesResponse.direccion);
                sqlCommand.Parameters.AddWithValue("@telefono", sucursalesResponse.telefono);
                sqlCommand.Parameters.AddWithValue("@email", sucursalesResponse.email);

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
        public async Task<SimpleResponse> ActualizarSucursales(int idsucursal, SucursalesResponse sucursalesResponse)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpers.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[Sp_Sucursales]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "ActualizarSucursal");
                sqlCommand.Parameters.AddWithValue("@idsucursal", sucursalesResponse.idsucursal);
                sqlCommand.Parameters.AddWithValue("@nombre_sucursal", sucursalesResponse.nombre_sucursal);
                sqlCommand.Parameters.AddWithValue("@direccion", sucursalesResponse.direccion);
                sqlCommand.Parameters.AddWithValue("@telefono", sucursalesResponse.telefono);
                sqlCommand.Parameters.AddWithValue("@email", sucursalesResponse.email);
                
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
        public async Task<SimpleResponse> EliminarSucursales(int idsucursal)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpers.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[Sp_Sucursales]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "EliminarSucursal");
                sqlCommand.Parameters.AddWithValue("@idsucursal", idsucursal);

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