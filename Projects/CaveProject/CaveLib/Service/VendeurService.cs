using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CaveLib.Bean;
using CaveLib.Controller;

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

        public Vendeur FindVendeur(Vendeur oVendeur)
        {
            return null;
        }

        IList<IBean> IService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
