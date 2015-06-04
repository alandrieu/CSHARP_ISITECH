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

            for (int i = 0; i < 10; i++ )
                createProducts(i);

            for (int i = 0; i < 10; i++)
                createVendeurs(i);

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

            // Create a Product...
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

        public void createVendeurs(int cpt)
        {
            Random rand = new Random();

            // Create a Product...
            var vendeur = new Bean.Vendeur
            {
                Name = "Alandrieu",
                Login = "USER#" + cpt.ToString(),
                Password = rand.Next().ToString()
            };

            // And save it to the database
            session.Save(vendeur);
            session.Flush();
        }

        public void createProducts(int cpt)
        {
            // Create a Product...
            var product = new Bean.Product
            {
                Name = "Reference#" + cpt.ToString(),
                Price = 500,
                Category = "Books"
            };

            // And save it to the database
            session.Save(product);
            session.Flush();
        }

 

    }
}
