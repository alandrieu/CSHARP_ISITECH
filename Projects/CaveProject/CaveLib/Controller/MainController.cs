using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate.Collection;

using NHibernate.Cfg;
//using NHibernate.Tool.hbm2ddl;

namespace CaveLib.Controller
{
    public class MainController
    {

        public NHibernate.ISessionFactory sessionsController;
        public NHibernate.ISession session;

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

            for (int i = 0; i < 50; i++ )
                createProducts();
        }

        public void createProducts()
        {
            // Create a Product...
            var product = new Bean.Product
            {
                Name = "Some C# Book",
                Price = 500,
                Category = "Books"
            };

            // And save it to the database
            session.Save(product);
            session.Flush();

            // Example http://coding-journal.com/setting-up-nhibernate-with-sqlite-using-visual-studio-2010-and-nuget/
        }

    }
}
