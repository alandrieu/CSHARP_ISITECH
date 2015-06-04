using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CaveLib.Bean;
using CaveLib.Controller;
using NHibernate;
using NHibernate.Criterion;

namespace CaveLib.Service
{
    /// <summary>
    /// Service pour la gestion des Vendeurs en Base de données
    /// </summary>
    public class VendeurService : Service.IService
    {
        private MainController currentDao;

        public VendeurService()
        {
            this.currentDao = MainController.CurrentDao;
        }

        /// <summary>
        /// Retrouver un et un seul Vendeur (via son Login)
        /// </summary>
        /// <param name="oVendeur"></param>
        /// <returns></returns>
        public IList<Bean.Vendeur> FindVendeur(Vendeur oVendeur)
        {
            // Note that we do not use the table name specified
            // in the mapping, but the class name, which is a nice
            // abstraction that comes with NHibernate
            //IQuery q = currentDao.session.CreateQuery("FROM Vendeur");
            //var list = q.List<Bean.Vendeur>();

            //// List all the entries' names
            //list.ToList().ForEach(p => Console.WriteLine(p.Name));

            ////
            //Console.Out.WriteLine("Next : " + Environment.NewLine);

            //var users = currentDao.sessionsController.Query<Vendeur>()
            //       .Where(x => x.UserName == "Abcd" && u.Password == "123456");
            //return null;

            IList<Bean.Vendeur> users = currentDao.session.CreateCriteria<Vendeur>()
                   .Add(Restrictions.Eq("Login", oVendeur.Login))
                   .List<Vendeur>();

            return users;
        }

        IList<IBean> IService.GetAll()
        {

            throw new NotImplementedException();
        }
    }
}
