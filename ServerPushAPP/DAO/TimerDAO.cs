using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ServerPushAPP.DAO;
namespace ServerPushAPP
{
    class TimerDAO
    {
        private SqlConnection cnn;
        private List<DBTimer> timerList = new List<DBTimer>();

        public TimerDAO()
        {
           
        }

        public void clearTimers()
        {
            timerList.Clear();
        }

        public void readTimers()
        {
            
            string query = "SELECT * FROM Timer";
            SqlDataReader reader = null;
            DBConection.dummyConnection();
            cnn = DBConection.cnn;
            SqlCommand cmd = new SqlCommand(query, cnn);
            
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DBTimer timer = new DBTimer();
                timer.id = int.Parse( reader[0].ToString());
                timer.horario =  reader[1].ToString();
                timer.frequencia = reader[2].ToString();
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
