using System.Data.SqlClient;
using MecanismoLoginAspNetMVC5.Models;
using MecanismoLoginAspNetMVC5.DAL.Conn;
using MecanismoLoginAspNetMVC5;
using System.Data;
using System.Collections.Generic;
using System;

namespace MecanismoLoginAspNetMVC5.DAL
{
    public class UsuarioDAL
    {
        public Conexao Conexao { get; set; }

        public UsuarioDAL()
        {
            Conexao = new Conexao();
        }

        public Usuario AcessoUsuario(Usuario usuario)
        {

            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();               

                SqlCommand comandoDML = new SqlCommand("SP_AcessoUsuarioV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@EmailUsuario", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@SenhaUsuario", SqlDbType.VarChar, 100);

                comandoDML.Parameters["@EmailUsuario"].Value = usuario.EmailUsuario;
                comandoDML.Parameters["@SenhaUsuario"].Value = usuario.SenhaUsuario;

                SqlDataReader dr = comandoDML.ExecuteReader();

                bool verificarUsuario = dr.HasRows;

                if (verificarUsuario == false)
                {
                    usuario = null;                    
                }
                else
                {
                    while (dr.Read())
                    {
                        string emailUsuario = Convert.ToString(dr["EmailUsuario"]);
                        string senhaUsuario = Convert.ToString(dr["SenhaUsuario"]);
                        usuario = new Usuario(emailUsuario, senhaUsuario);
                    }
                }

                conexao.Close();
                return usuario;
            }
        }
    }
}