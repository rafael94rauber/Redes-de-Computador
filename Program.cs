using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Data;

namespace IdentificarTipoArquivo
{
    class Program
    {
        private static SqlConnection conexaoDB;
        private const string CONN_STRING = @"Integrated Security=SSPI;Persist Security Info=False;User ID=rrauber;Initial Catalog=Sicred_Matone;Data Source=srvpdb18";


        static void Main(string[] args)
        {
            conexaoDB = CarregaConexao();

            using (SqlCommand comando = new SqlCommand())
            {
                comando.CommandText = "Select";
                comando.CommandType = CommandType.Text;
                comando.Connection = conexaoDB;
                comando.CommandTimeout = 30;

                SqlDataReader retornoQuery;
                retornoQuery = comando.ExecuteReader();

                while (retornoQuery.Read())
                {
                }
            }

            FecharConexao();
        }

        private static SqlConnection CarregaConexao()
        {
            if (conexaoDB is null)
            {
                conexaoDB = new SqlConnection(CONN_STRING);
            }
            else
            {
                FecharConexao();
                conexaoDB = new SqlConnection(CONN_STRING);
            }

            conexaoDB.Open();
            return conexaoDB;
        }

        private static void FecharConexao()
        {
            if (conexaoDB is null)
            {
                return;
            }

            conexaoDB.Close();
            conexaoDB.Dispose();
        }
    }
}
