using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveLib.Bean
{
    /// <summary>
    /// Classe pour la gestion des Vendeurs.
    /// </summary>
    public class Vendeur
    {
        public virtual Guid IdVendeur { get; set; }
        public virtual string Name { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }

        public Vendeur()
        {
        }

        /// <summary>
        /// Constructeur avec initialisation des paramètres
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public Vendeur(Guid id, String name, String login, String password)
        {
            this.Name = name;
            this.IdVendeur = id;
            this.Login = login;
            this.Password = password;
        }

        /// <summary>
        /// Détermine si l'objet spécifié est identique à l'objet actuel.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Sert de fonction de hachage par défaut.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
