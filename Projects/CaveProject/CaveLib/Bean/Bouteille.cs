using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveLib.Bean
{   
    /// <summary>
    /// Classe pour la gestion des Bouteilles.
    /// </summary>
    public class Bouteille : Product
    {

        public virtual Guid IdBouteille { get; set; }
        public virtual string Name { get; set; }
        public virtual string Category { get; set; }
        public virtual double PrixU { get; set; }

        public Bouteille()
        {
        }

        public Bouteille(Guid idBouteille, double prixU, String name, String category)
        {
            this.IdBouteille = idBouteille;

            this.PrixU = prixU;

            this.Name = name;

            this.Category = category;
        }
    }
}
