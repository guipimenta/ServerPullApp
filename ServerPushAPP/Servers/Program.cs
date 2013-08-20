using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;
using ServerPushAPP.DAO;


namespace ServerPushAPP
{
    class Program
    {
        static Thread server, updateServiceThread;
        static TimerDAO timerDAO;
        static UpdateService updateService;
        static void Main(string[] args)
        {

            //Para acessar o banco de dados
            doLogin();

            //Le timers e inicializa o servidor
            Console.WriteLine("\nCarregando timers disponíveis...");
            timerDAO = new TimerDAO();
            timerDAO.readTimers();
            Console.WriteLine("Número de timers carregados: " + timerDAO.getNumTimers());

            Console.WriteLine("\nInicializando servidor de timers...");
            
            TimerServer ts = new TimerServer(timerDAO.getTimerList());
            server = new Thread(ts.startTimer);
            server.Start();

            Console.WriteLine("Servidor inicializado com sucesso!");

            Console.WriteLine("\nInicializando serviço de update...");
            updateService = new UpdateService();
            updateServiceThread = new Thread(updateService.startService);
            updateServiceThread.Start();

            //Console
            //Possivelmente refatorar e colocar em uma classe
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
                    
                } else if(command.Equals("update")){
                    updateServer();
                }
                else if (command.Equals("force sync"))
                {
                    forceSync();
                }
                else
                {
                    Console.WriteLine("Comando inválido");
                }
                

            }
           
        }

        public static void forceSync()
        {
            Console.WriteLine("\n\nForçando sincronização...");
            String response = WebInterface.doGet("http://localhost:7800/dumyserver/example.json");
            Sync.doSync(response);
        }

        public static void updateServer()
        {
            //stop current server
            Console.WriteLine("\nParando servidor...");
            server.Suspend();

            Console.WriteLine("Recarregando lista de timers...");
            timerDAO.clearTimers();
            timerDAO.readTimers();

            Console.WriteLine("Servidor atualizado com sucesso!\n#");
            server.Resume();
            

        }

        //Sistema de login
        //TODO: refatorar e colocar em outra classe
        public static void doLogin()
        {

            do
            {
                Console.Clear();
                Console.WriteLine("USPeriodico Update Server v. 0.1");
                Console.WriteLine("-------------------------------");

                Console.Write("\n\nBem vindo!\n\nUsername: ");
                String username = Console.ReadLine();
                Console.Write("Password: ");
                String password = Utilitarios.getPassword();

                Console.WriteLine("\n\nInicializando conexão com SQL Server....");
                
                DBConection.conectDatabase(username, password);

            }
            while (!DBConection.isConnected);
            

        }
    }
}
