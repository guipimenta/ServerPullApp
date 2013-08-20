using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using ServerPushAPP.DAO;

namespace ServerPushAPP
{
    class Sync
    {
        public static void doSync(String response)
        {
            Palestra palestra = JsonResponse.parsePalestra(response);
            PalestraDAO palestraDAO = new PalestraDAO();
            palestraDAO.inserePalestra(palestra);
        }

    }
}
