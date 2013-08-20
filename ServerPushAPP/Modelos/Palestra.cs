using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerPushAPP
{
    class Palestra
    {
        public String nome {get; set;}
        public String descricao {get; set;}
        public int id { get; set; }
        public String imagemLink { get; set; }
        public bool valido { get; set; }
        public String dataModificacao { get; set; }
        public String dataInicio { get; set; }
        public String duracao { get; set; }
        public String local { get; set; }
        private List<String> palestrantes = new List<String>() ;

        public void addPalestrante(String nome)
        {
            palestrantes.Add(nome);
        }
        public String[] getPalestrantes()
        {
            return palestrantes.ToArray();
        }
    }
}
