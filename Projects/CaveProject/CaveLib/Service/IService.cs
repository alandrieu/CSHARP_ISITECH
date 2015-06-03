using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveLib.Service
{
    interface IService
    {
        IList<Bean.IBean> GetAll();
    }
}
