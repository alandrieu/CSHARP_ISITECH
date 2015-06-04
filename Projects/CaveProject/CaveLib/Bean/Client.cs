using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveLib.Bean
{
    /// <summary>
    /// Classe pour la gestion des Clients.
    /// </summary>
    public class Client : IBean
    {
        public virtual Guid IdClient { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}
