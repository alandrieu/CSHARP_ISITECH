using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CaveLib.Bean;
using System.ComponentModel;

namespace CaveLib.Model
{
    public class ProductView : INotifyPropertyChanged
    {
        private Product _product;

        public Product InnerProduct { get { return _product; } }

        public ProductView()
        {
            _product = new Product();
        }

        public ProductView(Product product)
        {
            _product = product;
        }

        public virtual Guid Id
        {
            get { return _product.Id; }
            set
            {
                _product.Id = value;
                NotifyPropertyChanged("Id");
            }
        }

        public virtual string Name
        {
            get { return _product.Name; }
            set
            {
                _product.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public virtual string Category
        {
            get { return _product.Category; }
            set
            {
                _product.Category = value;
                NotifyPropertyChanged("Category");
            }
        }

        public virtual int Price
        {
            get { return _product.Price; }
            set
            {
                _product.Price = value;
                NotifyPropertyChanged("Price");
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
