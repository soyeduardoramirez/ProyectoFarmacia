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
    public class Inventarios : IInventarios
    {
        public async Task<List<InventariosResponse>> ListadoInventarios()
        {
            List<InventariosResponse> Resultado = new List<InventariosResponse>();

            using (var conexion = new SqlConnection(Helpers.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[Sp_Inventarios]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "ListarInventarios");
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
                            new Models.InventariosResponse()
                            {
                                idinventario = lectura.GetInt32(0),
                                idproducto = lectura.GetInt32(1),
                                nombre_producto = lectura.GetString(2),
                                idsucursal = lectura.GetInt32(3),
                                nombre_sucursal=lectura.GetString(4),
                                stock = lectura.GetInt32(5)  
                            });
                    }
                }

                conexion.Close();
                return Resultado;
            }
        }
        public async Task<SimpleResponse> AgregarInventarios(InventariosResponse inventariosResponse)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpers.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[Sp_Inventarios]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "AgregarInventario");
                sqlCommand.Parameters.AddWithValue("@idproducto", inventariosResponse.idproducto);
                sqlCommand.Parameters.AddWithValue("@idsucursal", inventariosResponse.idsucursal);
                sqlCommand.Parameters.AddWithValue("@stock", inventariosResponse.stock);

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
        public async Task<SimpleResponse> ActualizarInventarios(int idinventario, InventariosResponse inventariosResponse)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpers.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[Sp_Inventarios]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "ActualizarInventario");
                sqlCommand.Parameters.AddWithValue("@idinventario", inventariosResponse.idinventario);
                sqlCommand.Parameters.AddWithValue("@idproducto", inventariosResponse.idproducto);
                sqlCommand.Parameters.AddWithValue("@idsucursal", inventariosResponse.idsucursal);
                sqlCommand.Parameters.AddWithValue("@stock", inventariosResponse.stock);

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
        public async Task<SimpleResponse> EliminarInventarios(int idinventario)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpers.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[Sp_Inventarios]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "EliminarInventario");
                sqlCommand.Parameters.AddWithValue("@idinventario", idinventario);

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
