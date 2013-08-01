using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;


namespace ServerPushAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("USPeriodico Update Server v. 0.1");
            Console.WriteLine("-------------------------------");

            Console.WriteLine("\n\nInicializando conexão com SQL Server....");
            TimerDAO timerDAO = new TimerDAO();

            Console.WriteLine("\nCarregando timers disponíveis...");
            timerDAO.readTimers();
            Console.WriteLine("Número de timers carregados: " + timerDAO.getNumTimers());

            Console.WriteLine("\nInicializando servidor de timers...");
            
            TimerServer ts = new TimerServer(timerDAO.getTimerList());
            Thread server = new Thread(ts.startTimer);
            server.Start();

            Console.WriteLine("Servidor inicializado com sucesso!");


            while (true)
            {
                Console.Write("\n\n#");

                String command = Console.ReadLine();

                if (command.Equals("list"))
                {
                    timerDAO.listTimers();
                } else
                if (command.Equals("quit"))
                {
                    Environment.Exit(0);
                }else if (command.Equals(""))
                {
                    
                } else {
                    Console.WriteLine("Comando inválido");
                    }
                

            }
           
        }
    }
}
