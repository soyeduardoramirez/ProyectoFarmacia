using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using VEFAC.Core.BL.Interfaces;
using VEFAC.Core.Models;

namespace VEFAC.Core.BL.Servicios
{
    public class Login : ILogin
    {
        public async Task<List<LoginResponse>> LoginUser(LoginResponse loginResponse)
        {
            List<LoginResponse> res = new List<LoginResponse>();
            using (var conexion = new SqlConnection(Helpers.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[Sp_Login]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@Email", loginResponse.email);
                sqlCommand.Parameters.AddWithValue("@Password", loginResponse.contrasena);
                #endregion


                var lectura = await sqlCommand.ExecuteReaderAsync();
                if (lectura.HasRows)
                {
                    while (lectura.Read())
                    {
                        res.Add(
                             new Models.LoginResponse()
                             {
                                 id = lectura.GetInt32(0),
                                 email = lectura.GetString(1),
                                 rol = lectura.GetString(2)
                             });
                    }
                }
                else
                {

                    var responseMsg = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("No se encontraron registros.")
                    };
                    throw new HttpResponseException(responseMsg);
                }

                conexion.Close();
                return res;
            }
        }
    }
}
