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
            cnn = DBConection.cnn;   
        }

        /*Implementar*/
        public void inserePalestra(Palestra palestra)
        {
            int valido;
            if (palestra.valido)
            {
                valido = 1;
            }
            else
            {
                valido = 0;
            }
            string query = "INSERT INTO dbo.palestras (ID, nome, descricao, imagemLink, valido, dataModificacao, dataInicio, duracao, local, palestrantes) ";
            query = query + "VALUES ('" + palestra.id + "','" + palestra.nome + "','" + palestra.descricao + "','" + palestra.imagemLink + "','" + valido + "','" + palestra.dataModificacao + "','" + palestra.dataInicio + "','" + palestra.duracao + "','";
            query = query + palestra.local + "','" + palestra.getPalestrantes().ElementAt(0) + "')";

            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.BeginExecuteNonQuery();
            

        }
    }
}
