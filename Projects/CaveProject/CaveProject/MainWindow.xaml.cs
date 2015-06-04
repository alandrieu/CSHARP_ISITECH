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
using System.Collections.Specialized;
//using System.Collections.Specialized;

namespace CaveProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Button> ButtonCollection { get; set; }

        private MainController mainController;

        private EcObservableCollection<ProductView> products;

        private Context context;

        private LoginWindow loginView;

        public MainWindow()
        {
            InitializeComponent();

            // Création des Button
            this.CreateButton();

            mainController = new MainController();

            this.InitHibernate();

            context = new Context();

            LaunchAuthMenu();
        }

        private void LaunchAuthMenu()
        {
            loginView = new LoginWindow();

            //loginView.Authenticated += isAuthenticated;
            loginView.Closing += loginViewIsClosed;

            //loginView.Show();
            loginView.ShowDialog();
        }


        /// <summary>
        /// Méthode de gestion de la fermeture de 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginViewIsClosed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Si le module d'authentification n'a pas trouvé un vendeur on ferme l'application
            if (loginView.currentVendeur == null)
                this.Close();
            else
            {
                // Récupération de l'utilisateur Courant
                context.Vendeur = loginView.currentVendeur;

                // Mise à jour du menu
                headerAccountName.Header = context.Vendeur.Name;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
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

        public void CreateButton()
        {
            ButtonCollection = new List<Button>();

            IDictionary<String, String> oCollection = new Dictionary<String, String>();

            oCollection.Add("Login", "");
            oCollection.Add("Game", "");
            oCollection.Add("Google", "https://www.google.fr/images/srpr/logo11w.png");
            
            foreach (KeyValuePair<string, string> entry in oCollection)
            {
                // You could parse your XML and update the collection
                // Also implement INotifyPropertyChanged

                //Dummy Data for Demo 
                Button objButton = new Button() { Height = 40, Width = 105, Name = entry.Key, Content = entry.Key };

                if (objButton.Name.Equals("Login"))
                    objButton.Click += ButtonLogin_Click;
                else
                    objButton.Click += Button_Click;

                ButtonCollection.Add(objButton);
                //YourCollection.Add(new Button() { Height = 25, Width = 25 });
            }

            this.DataContext = this;
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            View.LoginWindow loginView = new View.LoginWindow();

            //loginView.Show();
            loginView.ShowDialog();
            //throw new NotImplementedException();
        }
    }
}