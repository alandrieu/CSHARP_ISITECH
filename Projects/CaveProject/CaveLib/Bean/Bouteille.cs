using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveLib.Bean
{
    class Bouteille
    {
        public int IdBouteille { get; private set; }

        public double PrixU { get; private set; }
        public String Name { get; private set; }

        public Bouteille()
        {
            IdBouteille = 0;
            PrixU = 0;
        }

        public Bouteille(int idBouteille, double prixU, String name)
        {
            this.IdBouteille = idBouteille;

            this.PrixU = prixU;

            this.Name = name;
        }
    }
}
