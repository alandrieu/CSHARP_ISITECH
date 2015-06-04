using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CaveLib.Bean;
using System.ComponentModel;

namespace CaveLib.Model
{
    public class BouteilleView : INotifyPropertyChanged
    {
        private Bouteille _bouteille;

        public Bouteille InnerBouteille { get { return _bouteille; } }

        public BouteilleView()
        {
            _bouteille = new Bouteille();
        }

        public BouteilleView(Bouteille bouteille)
        {
            _bouteille = bouteille;
        }

        public virtual Guid IdBouteille
        {
            get { return _bouteille.IdBouteille; }
            set
            {
                _bouteille.IdBouteille = value;
                NotifyPropertyChanged("IdBouteille");
            }
        }

        public virtual string Name
        {
            get { return _bouteille.Name; }
            set
            {
                _bouteille.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public virtual string Category
        {
            get { return _bouteille.Category; }
            set
            {
                _bouteille.Category = value;
                NotifyPropertyChanged("Category");
            }
        }

        public virtual double PrixU
        {
            get { return _bouteille.PrixU; }
            set
            {
                _bouteille.PrixU = value;
                NotifyPropertyChanged("PrixU");
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
