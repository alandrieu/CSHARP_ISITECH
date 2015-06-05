using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCsharpLib.Dao
{
    /// <summary>
    /// Accès à la base de données via Hibernate
    /// </summary>
    public class Dao
    {
        public NHibernate.ISessionFactory sessionsController;
        public NHibernate.ISession session;

        public static Dao CurrentDao { get; set; }

        Configuration cfg;

        public Dao()
        {
            // Init Cave
            // Initialize NHibernate
            cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Bean.Contact).Assembly);
            //new SchemaExport(cfg).Execute(true, true, false);

            // Get ourselves an NHibernate Session
            //var sessions = cfg.BuildSessionFactory();
            sessionsController = cfg.BuildSessionFactory();

            session = sessionsController.OpenSession();

            for (int i = 0; i < 10; i++)
                createContact();
        }

        /// <summary>
        /// Méthode qui créer un utilisateur par défaut pour la démonstration
        /// </summary>
        private void createContact()
        {
            Random rand = new Random();

            // Créer un Vendeur
            Bean.Contact contact = new Bean.Contact();
            //{
            //    Name = "Isitech Account",
            //    Login = "ISITECH",
            //    Password = Hashing.SHA512("ISITECH")
            //};

            // And save it to the database
            session.Save(contact);
            session.Flush();
        }
    }
}
