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
    /// Interaction logic for VendeurUserControl.xaml
    /// </summary>
    public partial class VendeurUserControl : UserControl
    {
        private MainController mainController;

        private EcObservableCollection<VendeurView> vendeurs;

        private Context context;

        public VendeurUserControl()
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
                var criteria = session.CreateCriteria<Vendeur>();
                vendeurs = new EcObservableCollection<VendeurView>();
                foreach (Vendeur c in criteria.List<Vendeur>())
                    vendeurs.Add(new VendeurView(c));
            }

            vendeurs.CollectionChanged +=
                new NotifyCollectionChangedEventHandler(vendeurs_CollectionChanged);
            vendeurs.ItemChanged +=
                new EcObservableCollection<VendeurView>.EcObservableCollectionItemChangedEventHandler(vendeurs_ItemChanged);
            dataGrid1.ItemsSource = vendeurs;
        }

        public void vendeurs_ItemChanged(object sender, EcObservableCollectionItemChangedEventArgs<VendeurView> args)
        {
            using (var session = mainController.sessionsController.OpenSession())
            {
                session.SaveOrUpdate(args.Item.InnerVendeur);
                session.Flush();
            }
        }

        public void vendeurs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            using (var session = mainController.sessionsController.OpenSession())
            {
                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        foreach (VendeurView c in e.OldItems)
                        {
                            session.Delete(c.InnerVendeur);
                            session.Flush();
                        }
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        foreach (VendeurView c in e.NewItems)
                            session.Save(c.InnerVendeur);
                        break;
                    default:
                        foreach (VendeurView c in e.OldItems)
                            session.SaveOrUpdate(c.InnerVendeur);
                        break;
                }
            }

        }
    }
}
