using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CaveLib.Bean;
using System.ComponentModel;

namespace CaveLib.Model
{
    public class ClientView : INotifyPropertyChanged
    {
        private Client _client;

        public Client InnerClient { get { return _client; } }

        public ClientView()
        {
            _client = new Client();
        }

        public ClientView(Client client)
        {
            _client = client;
        }

        public virtual Guid IdClient
        {
            get { return _client.IdClient; }
            set
            {
                _client.IdClient = value;
                NotifyPropertyChanged("IdClient");
            }
        }

        public virtual string FirstName
        {
            get { return _client.FirstName; }
            set
            {
                _client.FirstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }

        public virtual string LastName
        {
            get { return _client.LastName; }
            set
            {
                _client.LastName = value;
                NotifyPropertyChanged("LastName");
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
