using RestService.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RestService.Persistencia
{
    public class UsuarioDAO
    {
        public List<Usuario> ListarTodos()
        {
            List<Usuario> usuariosEncontrados = new List<Usuario>();
            Usuario usuarioEncontrado = null;
            string sql = "SELECT * FROM ZOSCM_INT_USUARIO";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            usuarioEncontrado = new Usuario()
                            {
                                Nombres = (string)resultado["CHRNOMUSR"],
                                ClaveCorreo = (string)resultado["CHRAPEPAT"]
                            };
                            usuariosEncontrados.Add(usuarioEncontrado);
                        }
                    }
                }
            }
            return usuariosEncontrados;
        }
        public Usuario LoginUsuarios(string usuario,string clave)
        {
            Usuario usuarioEncontrado = null;
            string output = "";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("sp_RRHH_Login_S_2", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@Opcion", SqlDbType.Int).Value = 2;
                    com.Parameters.Add("@Usuario", SqlDbType.VarChar, 30).Value = usuario;
                    com.Parameters.Add("@Clave", SqlDbType.VarChar, 30).Value = clave;

                    // com.Parameters.Add("@Resultado", SqlDbType.VarChar, 100);
                    // com.Parameters["@Resultado"].Direction = ParameterDirection.Output;

                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            usuarioEncontrado = new Usuario();
                            usuarioEncontrado.UsuarioId = (int)resultado["UsuarioId"];
                            usuarioEncontrado.UsuarioLogin = (string)resultado["Usuario"];
                            usuarioEncontrado.ApellidoPaterno = (string)resultado["ApellidoPaterno"];
                            usuarioEncontrado.ApellidoMaterno = (string)resultado["ApellidoMaterno"];
                            usuarioEncontrado.Nombres = (string)resultado["Nombres"];
                            usuarioEncontrado.Clave = (string)resultado["Clave"];
                            usuarioEncontrado.ClaveCorreo = (string)resultado["ClaveCorreo"];
                            usuarioEncontrado.Estado = (bool)resultado["Estado"];
                            usuarioEncontrado.Respuesta = (string)resultado["Respuesta"];

                        }
                    }
                }
            }

            return usuarioEncontrado;
        }
    }
}