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
    public class ProductosConsulta:IProductosConsulta
    {
        public async Task<List<ProductosConsultaResponse>> ListadoProductosConsulta()
        {
            List<ProductosConsultaResponse> Resultado = new List<ProductosConsultaResponse>();

            using (var conexion = new SqlConnection(Helpers.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[Sp_Productos]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "ListarProductos");
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
                            new Models.ProductosConsultaResponse()
                            {
                                idproducto = lectura.GetInt32(0),
                                nombrecategoria = lectura.GetString(1),
                                idcategoria = lectura.GetInt32(2),
                                nombremarca = lectura.GetString(3),
                                idmarca = lectura.GetInt32(4),
                                nombre_producto = lectura.GetString(5),
                                precio = lectura.GetDecimal(6),
                                imagen = lectura.GetString(7)
                            });
                    }
                }

                conexion.Close();
                return Resultado;
            }
        }
    }
}
