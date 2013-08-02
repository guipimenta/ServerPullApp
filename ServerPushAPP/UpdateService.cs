using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace ServerPushAPP
{
    class UpdateService
    {
        static Timer _timer; // From System.Timers
        static int timeout = 60000;
        public  void startService()
        {
            
            _timer = new Timer(timeout);
            _timer.Elapsed += new ElapsedEventHandler(timerTimeOut);
            _timer.Enabled = true; // Enable it
            Console.WriteLine("\nServiço de update inicializado com sucesso!");
        }

        public  void timerTimeOut(object sender, ElapsedEventArgs e)
        {
            //Periodical update server
            Program.updateServer();
        }
    }
}
