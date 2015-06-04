using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveLib.Service
{
    /// <summary>
    /// Interface des Services pour les accès à la base de données
    /// </summary>
    interface IService
    {
       IList<Bean.IBean> GetAll();
    }
}
