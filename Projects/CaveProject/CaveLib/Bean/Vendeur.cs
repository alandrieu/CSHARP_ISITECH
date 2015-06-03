using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveLib.Bean
{
    class Vendeur
    {
        public int IdVendeur { get; private set; }

        public String Login { get; private set; }
        public String Password { get; private set; }

        public Vendeur(int id, String login, String password)
        {
            this.IdVendeur = id;
            this.Login = login;
            this.Password = password;
        }
    }
}
