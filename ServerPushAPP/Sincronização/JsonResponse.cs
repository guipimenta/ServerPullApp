using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ServerPushAPP
{
    class JsonResponse
    {
        public static List<Palestra> parsePalestra(String jsonString)
        {
            JsonTextReader jtr = new JsonTextReader(new StringReader(jsonString));
            Console.WriteLine("\n\nInicializando sincronização de palestras...");
            List<String> atributos = new List<String>();
            int quantidade=0;
           
            
            while (jtr.Read())
            {
                if (jtr.Value!=null && jtr.Value.ToString().Equals("quantidade"))
                {
                    jtr.Read();
                    quantidade = int.Parse(jtr.Value.ToString());
                    //Console.WriteLine(jtr.Value.ToString());
                    jtr.Read();
                }
           
                if (jtr.TokenType.ToString().Equals("String") )
                {
                  
                    atributos.Add(jtr.Value.ToString());
                  // Console.WriteLine(jtr.Value.ToString());

                }
            }

            int j = 0;
            List<Palestra> palestras = new List<Palestra>();
            for (int i = 0; i < quantidade; i++)
            {

                palestras.Add(new Palestra());
                palestras.ElementAt(i).nome = atributos.ElementAt(j); j++;
                palestras.ElementAt(i).descricao = atributos.ElementAt(j); j++;
                palestras.ElementAt(i).id = int.Parse(atributos.ElementAt(j)); j++;
                palestras.ElementAt(i).imagemLink = atributos.ElementAt(j); j++;
                    if (atributos.ElementAt(j).Equals("True"))
                       palestras.ElementAt(i).valido = true;
                    else
                       palestras.ElementAt(i).valido = false;
                    j++;
                    palestras.ElementAt(i).dataModificacao = atributos.ElementAt(j); j++;
                    palestras.ElementAt(i).dataInicio = atributos.ElementAt(j); j++;
                    palestras.ElementAt(i).duracao = atributos.ElementAt(j); j++;
                    palestras.ElementAt(i).local = atributos.ElementAt(j); j++;
                   while(!atributos.ElementAt(j).Equals("fim"))
                   {
                       palestras.ElementAt(i).addPalestrante(atributos.ElementAt(j));
                       j++;
                   }
                   j++;

            }
           /* /*Inicializa objeto palestra*/

            /*Palestra palestra = new Palestra();
            palestra.nome = atributos.ElementAt(0);
            palestra.descricao = atributos.ElementAt(1);
            palestra.id = int.Parse(atributos.ElementAt(2));
            palestra.imagemLink = atributos.ElementAt(3);
            if (atributos.ElementAt(4).Equals("True"))
                palestra.valido = true;
            else
                palestra.valido = false;
            palestra.dataModificacao = atributos.ElementAt(5);
            palestra.dataInicio = atributos.ElementAt(6);
            palestra.duracao = atributos.ElementAt(7);
            palestra.local = atributos.ElementAt(8);
            for (int i = 9; i < atributos.Count(); i++)
            {
                palestra.addPalestrante(atributos.ElementAt(i));
            }
             */

            return palestras;
            
        }
    }
}
