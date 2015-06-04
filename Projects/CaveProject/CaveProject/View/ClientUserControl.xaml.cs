using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using CaveLib.Controller;
using CaveLib.Model.Collection;
using CaveLib.Model;
using CaveLib.Bean;
using CaveProject.View;
using CaveProject.CustomItem;
using System.Collections.Specialized;

namespace CaveProject.View
{
    /// <summary>
    /// Interaction logic for ClientUserControl.xaml
    /// </summary>
    public partial class ClientUserControl : UserControl
    {
        private MainController mainController;

        private EcObservableCollection<ClientView> clients;

        private Context context;

        public ClientUserControl()
        {
            InitializeComponent();

            mainController = MainController.CurrentDao;
            context = Context.CurrentContext;

            this.InitHibernate();
        }

        public void InitHibernate()
        {
            using (var session = mainController.sessionsController.OpenSession())
            {
                var criteria = session.CreateCriteria<Client>();
                clients = new EcObservableCollection<ClientView>();
                foreach (Client c in criteria.List<Client>())
                    clients.Add(new ClientView(c));
            }

            clients.CollectionChanged +=
                new NotifyCollectionChangedEventHandler(clients_CollectionChanged);
            clients.ItemChanged +=
                new EcObservableCollection<ClientView>.EcObservableCollectionItemChangedEventHandler(clients_ItemChanged);
            dataGrid1.ItemsSource = clients;
        }

        public void clients_ItemChanged(object sender, EcObservableCollectionItemChangedEventArgs<ClientView> args)
        {
            using (var session = mainController.sessionsController.OpenSession())
            {
                session.SaveOrUpdate(args.Item.InnerClient);
                session.Flush();
            }
        }

        public void clients_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            using (var session = mainController.sessionsController.OpenSession())
            {
                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        foreach (ClientView c in e.OldItems)
                        {
                            session.Delete(c.InnerClient);
                            session.Flush();
                        }
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        foreach (ClientView c in e.NewItems)
                            session.Save(c.InnerClient);
                        break;
                    default:
                        foreach (ClientView c in e.OldItems)
                            session.SaveOrUpdate(c.InnerClient);
                        break;
                }
            }

        }
    }
}
