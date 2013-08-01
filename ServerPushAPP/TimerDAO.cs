using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ServerPushAPP
{
    class TimerDAO
    {
        private SqlConnection cnn;
        private List<DBTimer> timerList = new List<DBTimer>();

        public TimerDAO()
        {
            string connetionString = null;
            
            connetionString = "Data Source=localhost;Initial Catalog=usperiodico;User ID=usperiodico;Password=abc123123";
            cnn = new SqlConnection(connetionString);

            try
            {
                cnn.Open();
                Console.WriteLine("Conectado");
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível conectar ao banco de dados...");
            }
        }

        public void readTimers()
        {
            string query = "SELECT * FROM Timer";
            SqlDataReader reader = null;

            SqlCommand cmd = new SqlCommand(query, cnn);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DBTimer timer = new DBTimer();
                timer.horario =  reader[0].ToString();
                timer.frequencia = reader[1].ToString();
                timerList.Add(timer);
            }
            
        }

        public void listTimers()
        {
            Console.WriteLine("Horario\t\tFrequência");
            foreach(DBTimer dbtimer in timerList)
            {
                Console.WriteLine(dbtimer.horario + "\t\t" + dbtimer.frequencia);
            }
        }

        public int getNumTimers()
        {
            return timerList.Count;
        }

        public List<DBTimer> getTimerList()
        {
            return timerList;
        }
    }
}
