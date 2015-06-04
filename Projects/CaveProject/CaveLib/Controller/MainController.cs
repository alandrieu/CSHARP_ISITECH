using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Hibernate Lib
using NHibernate.Collection;
using NHibernate.Cfg;

//
using CaveLib.Utils;

namespace CaveLib.Controller
{
    /// <summary>
    /// Le MainController créer toutes les connexions avec la Base de données et initialise Hibernate.
    /// Il peuple aussi la BDD en Vendeur, Commande, Bouteille, Client.
    /// </summary>
    public class MainController
    {

        public NHibernate.ISessionFactory sessionsController;
        public NHibernate.ISession session;

        public static MainController CurrentDao{get; set;}

        Configuration cfg;

        public MainController()
        {
            // Init Cave
            // Initialize NHibernate
            cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Bean.Product).Assembly);
            //new SchemaExport(cfg).Execute(true, true, false);

            // Get ourselves an NHibernate Session
            //var sessions = cfg.BuildSessionFactory();
            sessionsController = cfg.BuildSessionFactory();

            session = sessionsController.OpenSession();

            for (int i = 0; i < 10; i++)
                createVendeurs(i);

            for (int i = 0; i < 10; i++)
                createBouteilles(i);

            for (int i = 0; i < 10; i++)
                createCustomers(i);

            CurrentDao = this;

            // Créer un utilisateur par défaut
            createADefaultVendeur();
        }

        /// <summary>
        /// Méthode qui créer un utilisateur par défaut pour la démonstration
        /// </summary>
        private void createADefaultVendeur()
        {
            Random rand = new Random();

            // Créer un Vendeur
            var vendeur = new Bean.Vendeur
            {
                Name = "Isitech Account",
                Login = "ISITECH",
                Password = Hashing.SHA512("ISITECH")
            };

            // And save it to the database
            session.Save(vendeur);
            session.Flush();
        }

        private void createVendeurs(int cpt)
        {
            Random rand = new Random();

            // Créer un Vendeur
            var vendeur = new Bean.Vendeur
            {
                Name = "Alandrieu",
                Login = "USER#" + cpt.ToString(),
                Password = Hashing.SHA512(rand.Next().ToString())
            };

            // And save it to the database
            session.Save(vendeur);
            session.Flush();
        }

        private void createBouteilles(int cpt)
        {
            // Créer une Bouteille
            var bouteille = new Bean.Bouteille
            {
                Name = "Château Haut Vigneau Pessac-Léognan#" + cpt.ToString(),
                PrixU = 56,
                Category = "Vin Rouge"
            };

            // And save it to the database
            session.Save(bouteille);
            session.Flush();
        }

        private void createCustomers(int cpt)
        {
            // Créer une Client
            var client = new Bean.Client
            {
                FirstName = "Jean#" + cpt.ToString(),
                LastName = "Du Lac"
            };

            // And save it to the database
            session.Save(client);
            session.Flush();
        }
 

    }
}
