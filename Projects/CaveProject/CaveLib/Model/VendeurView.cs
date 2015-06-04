using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CaveLib.Bean;
using System.ComponentModel;

namespace CaveLib.Model
{
    public class VendeurView : INotifyPropertyChanged
    {
        private Vendeur _vendeur;

        public Vendeur InnerVendeur { get { return _vendeur; } }

        public VendeurView()
        {
            _vendeur = new Vendeur();
        }

        public VendeurView(Vendeur vendeur)
        {
            _vendeur = vendeur;
        }

        public virtual Guid IdVendeur
        {
            get { return _vendeur.IdVendeur; }
            set
            {
                _vendeur.IdVendeur = value;
                NotifyPropertyChanged("IdVendeur");
            }
        }

        public virtual string Name
        {
            get { return _vendeur.Name; }
            set
            {
                _vendeur.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public virtual string Login
        {
            get { return _vendeur.Login; }
            set
            {
                _vendeur.Login = value;
                NotifyPropertyChanged("Login");
            }
        }

        public virtual string Password
        {
            get { return _vendeur.Password; }
            set
            {
                _vendeur.Password = value;
                NotifyPropertyChanged("Password");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyChanged)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
        }

        #endregion
    }
}
