using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveLib.Bean
{
    class Commande
    {
        public int IdCmd {get; private set;}

        public int IdVendeur { get; private set; }

        public IList<Bouteille> LstBouteille { get; private set; }

        public Commande()
        {
            IdCmd = 0;
            IdVendeur = 0;
            LstBouteille = new List<Bouteille>();
        }
    }
}
