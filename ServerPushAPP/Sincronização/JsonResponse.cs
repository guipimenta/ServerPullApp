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
        public static Palestra parsePalestra(String jsonString)
        {
            JsonTextReader jtr = new JsonTextReader(new StringReader(jsonString));
            Console.WriteLine("Inicializando sincronização de palestras...");
            List<String> atributos = new List<String>();
            
            while (jtr.Read())
            {
                if (jtr.TokenType.ToString().Equals("String"))
                {
                    atributos.Add(jtr.Value.ToString());
                   // Console.WriteLine(jtr.Value.ToString());
                } 
            }

            /*Inicializa objeto palestra*/

            Palestra palestra = new Palestra();
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
            return palestra;
            
        }
    }
}
