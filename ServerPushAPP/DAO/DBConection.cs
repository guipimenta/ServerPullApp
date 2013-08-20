using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ServerPushAPP.DAO
{
    class DBConection
    {
        public static bool isConnected;
        public static SqlConnection cnn;
        static string username;
        static string password;

        public static void conectDatabase(String username, String password)
        {
            string connetionString = null;
            DBConection.username = username;
            DBConection.password = password;
            connetionString = "Data Source=localhost;Initial Catalog=usperiodico;User ID=" + username + ";Password=" + password;
            cnn = new SqlConnection(connetionString);

            try
            {
                cnn.Open();
                Console.WriteLine("Conectado");
                isConnected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível conectar ao banco de dados...");
                isConnected = false;

            }
        }

        public static void dummyConnection()
        {
            DBConection.conectDatabase(DBConection.username, DBConection.password);
        }

        public bool connectionStatus()
        {
            return isConnected;
        }

        public SqlConnection getConexao()
        {
            return cnn;
        }
    }
}
