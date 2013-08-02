using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ServerPushAPP
{
    class WebInterface
    {
        //Metodo que retorna a resposta do servidor
        //Provavelmente o objeto json
        public static  String doGet(String url)
        {
            String response = "";

            WebRequest geturl;
            geturl = WebRequest.Create(url);

            Stream objStream;
            objStream = geturl.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);

            string sline = "";

            while (sline != null)
            {
                sline = objReader.ReadLine();
                if (sline != null)
                    response = response + sline + "\n";

            }


            //Debug only
            Console.WriteLine("\nResposta do servidor:");
            Console.WriteLine(response);
            for (int i = 0; i < 100000000; i++) { }

            return response;
        }
    }
}
