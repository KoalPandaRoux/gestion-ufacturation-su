using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_ufacturation.SHARED
{
    public class Clients
    {
        public int id { set; get; }
        public string nom { set; get; }
        public string prenom { set; get; }
        public string numero_telephone { set; get; }
        public string adresse { set; get; }

        public DateTime DateAjout { get; set; }
    }
}

