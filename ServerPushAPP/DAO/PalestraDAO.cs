using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ServerPushAPP.DAO
{
    class PalestraDAO
    {
        private SqlConnection cnn;
        public PalestraDAO()
        {
          
        }

        public void inserePalestra(List<Palestra> palestras)
        {
           
           
            for (int i = 0; i < palestras.Count; i++)
            {
                DBConection.dummyConnection();
                this.cnn = DBConection.cnn;
                int valido;
                if (palestras.ElementAt(i).valido)
                {
                    valido = 1;
                }
                else
                {
                    valido = 0;
                }
                string query = "INSERT INTO dbo.palestras (ID, nome, descricao, imagemLink, valido, dataModificacao, dataInicio, duracao, local, palestrantes) ";
                query = query + "VALUES ('" + palestras.ElementAt(i).id + "','" + palestras.ElementAt(i).nome + "','" + palestras.ElementAt(i).descricao + "','" + palestras.ElementAt(i).imagemLink + "','" + valido + "','" + palestras.ElementAt(i).dataModificacao + "','" + palestras.ElementAt(i).dataInicio + "','" + palestras.ElementAt(i).duracao + "','";
                query = query + palestras.ElementAt(i).local + "','" + palestras.ElementAt(i).getPalestrantes().ElementAt(0) + "')";

                SqlCommand cmd = new SqlCommand(query, cnn);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                }
               
                this.cnn.Close();
            }

            Console.WriteLine("\n\nServidor atualizado com sucesso!");

        }

    }
}
