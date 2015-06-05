using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectCsharpLib.Dao;
using ProjectCsharpLib.Bean;
using NHibernate.Criterion;

namespace ProjectCsharpLib.Service
{
    /// <summary>
    /// 
    /// </summary>
    class ContactService
    {
        private ProjectCsharpLib.Dao.Dao currentDao;

        public ContactService()
        {
            this.currentDao = ProjectCsharpLib.Dao.Dao.CurrentDao;
        }

        /// <summary>
        /// Retrouver un et un seul Vendeur (via son Login)
        /// </summary>
        /// <param name="oVendeur"></param>
        /// <returns></returns>
        public IList<Bean.Contact> FindVendeur(Contact oContact)
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

            IList<Bean.Contact> users = currentDao.session.CreateCriteria<Contact>()
                   .Add(Restrictions.Eq("Nom", oContact.Nom))
                   .List<Contact>();

            return users;
        }
    }
}
