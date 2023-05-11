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
    public class Ventas : IVentas
    {
        public async Task<List<VentasResponse>> ListadoVentas()
        {
            List<VentasResponse> Resultado = new List<VentasResponse>();

            using (var conexion = new SqlConnection(Helpers.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[Sp_Ventas]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "ListarVentas");
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
                            new Models.VentasResponse()
                            {
                                idventa = lectura.GetInt32(0),
                                idempleado = lectura.GetInt32(1),
                                nombre_empleado = lectura.GetString(2),
                                apellido_empleado = lectura.GetString(3),
                                
                                idcliente = lectura.GetInt32(4),
                                nombre_cliente = lectura.GetString(5),
                                apellido_cliente = lectura.GetString(6),
                                idproducto = lectura.GetInt32(7),
                                nombre_producto = lectura.GetString(8),
                                cantidad = lectura.GetInt32(9),
                                fecha = lectura.GetDateTime(10),
                                subtotal = lectura.GetDecimal(11),
                                impuestos = lectura.GetInt32(12),
                                total = lectura.GetDecimal(13)
                            });
                    }
                }

                conexion.Close();
                return Resultado;
            }
        }
        public async Task<SimpleResponse> AgregarVentas(VentasResponse ventasResponse)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpers.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[Sp_Ventas]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "AgregarVenta");
                sqlCommand.Parameters.AddWithValue("@idproducto", ventasResponse.idproducto);
                sqlCommand.Parameters.AddWithValue("@idempleado", ventasResponse.idempleado);
                sqlCommand.Parameters.AddWithValue("@idcliente", ventasResponse.idcliente);
                sqlCommand.Parameters.AddWithValue("@cantidad", ventasResponse.cantidad);
                sqlCommand.Parameters.AddWithValue("@fecha", ventasResponse.fecha);
                sqlCommand.Parameters.AddWithValue("@subtotal", ventasResponse.subtotal);
                sqlCommand.Parameters.AddWithValue("@impuestos", ventasResponse.impuestos);
                sqlCommand.Parameters.AddWithValue("@total", ventasResponse.total);

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
        public async Task<SimpleResponse> ActualizarVentas(int idventa, VentasResponse ventasResponse)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpers.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[Sp_Ventas]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "ActualizarVenta");
                sqlCommand.Parameters.AddWithValue("@idventa", ventasResponse.idventa);
                sqlCommand.Parameters.AddWithValue("@idempleado", ventasResponse.idempleado);
                sqlCommand.Parameters.AddWithValue("@idcliente", ventasResponse.idcliente);
                sqlCommand.Parameters.AddWithValue("@idproducto", ventasResponse.idproducto);
                sqlCommand.Parameters.AddWithValue("@cantidad", ventasResponse.cantidad);
                sqlCommand.Parameters.AddWithValue("@fecha", ventasResponse.fecha);
                sqlCommand.Parameters.AddWithValue("@subtotal", ventasResponse.subtotal);
                sqlCommand.Parameters.AddWithValue("@impuestos", ventasResponse.impuestos);
                sqlCommand.Parameters.AddWithValue("@total", ventasResponse.total);

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
        public async Task<SimpleResponse> EliminarVentas(int idventa)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpers.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[Sp_Ventas]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "EliminarVenta");
                sqlCommand.Parameters.AddWithValue("@idventa", idventa);

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


