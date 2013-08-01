using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;

namespace ServerPushAPP
{

    class TimerServer
    {
        Boolean request = false;
        private List<DBTimer> DBTimers;
        public TimerServer(List<DBTimer> DBTimers)
        {
            //Carrega os timers
            this.DBTimers = DBTimers;
        }

        public void startTimer()
        {
            while (true)
            {
                String horarioAtual = DateTime.Now.ToString("HH:mm");
                horarioAtual = "12:00";
                for (int i = 0; i < DBTimers.Count; i++)
                {
                    DBTimer dbTimer = DBTimers.ElementAt(i);
                    String[] splited = dbTimer.horario.Split(':');
                    String horario = splited[0] + ":" + splited[1];
                    if (horario.Equals(horarioAtual))
                    {
                        //Faz tratamento
                        //Sincronizacao com o banco de dados
                        this.startSync();
                    }
                }
            }
            
        }

        public void startSync()
        {

            WebInterface.doGet("http://localhost:7800/dumyserver/json.txt.txt");
                    request = false;
        }

    }
}
