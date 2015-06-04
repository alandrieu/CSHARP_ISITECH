using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CaveLib.Bean;
namespace CaveLib.Controller
{
    public class Context
    {
        public Vendeur Vendeur { get; set; }

        public static Context CurrentContext {get; set;}


        public Context()
        {
            CurrentContext = this;
        }
    }
}
