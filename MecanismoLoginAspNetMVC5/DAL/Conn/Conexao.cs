using System.Data.SqlClient;
using System.Configuration;

namespace MecanismoLoginAspNetMVC5.DAL.Conn
{
    public class Conexao
    {
        private const string stringConn = @"Server=DESKTOP-1T99VF9; Database=DB_ACESSO; User Id=sa; Password=123@qwe;";

        public SqlConnection ConexaoDatabase()
        {
            return new SqlConnection(stringConn);
        }
    }
}