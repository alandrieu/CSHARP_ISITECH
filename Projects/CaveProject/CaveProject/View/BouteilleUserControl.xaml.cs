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
    /// Interaction logic for BouteilleUserControl.xaml
    /// </summary>
    public partial class BouteilleUserControl : UserControl
    {
        private MainController mainController;

        private EcObservableCollection<ProductView> products;

        private Context context;

        public BouteilleUserControl()
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
                var criteria = session.CreateCriteria<Product>();
                products = new EcObservableCollection<ProductView>();
                foreach (Product c in criteria.List<Product>())
                    products.Add(new ProductView(c));
            }

            products.CollectionChanged +=
                new NotifyCollectionChangedEventHandler(products_CollectionChanged);
            products.ItemChanged +=
                new EcObservableCollection<ProductView>.EcObservableCollectionItemChangedEventHandler(products_ItemChanged);
            dataGrid1.ItemsSource = products;
        }

        public void products_ItemChanged(object sender, EcObservableCollectionItemChangedEventArgs<ProductView> args)
        {
            using (var session = mainController.sessionsController.OpenSession())
            {
                session.SaveOrUpdate(args.Item.InnerProduct);
                session.Flush();
            }
        }

        public void products_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            using (var session = mainController.sessionsController.OpenSession())
            {
                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        foreach (ProductView c in e.OldItems)
                        {
                            session.Delete(c.InnerProduct);
                            session.Flush();
                        }
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        foreach (ProductView c in e.NewItems)
                            session.Save(c.InnerProduct);
                        break;
                    default:
                        foreach (ProductView c in e.OldItems)
                            session.SaveOrUpdate(c.InnerProduct);
                        break;
                }
            }

        }
    }
}
