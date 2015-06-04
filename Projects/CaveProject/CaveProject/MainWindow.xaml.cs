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
//using System.Collections.Specialized;

namespace CaveProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainController mainController;

        private Context context;

        private LoginWindow loginView;

        public MainWindow()
        {
            InitializeComponent();

            // Création des Button
            //this.CreateButton();

            mainController = new MainController();

            //this.InitHibernate();

            context = new Context();

            LaunchAuthMenu();

            // Mise en place de l'icone
            this.Icon = new BitmapImage(new Uri("./Ressources/iconeApp.ico", UriKind.Relative));
        }

        /// <summary>
        /// Lancement du menu d'authentification
        /// </summary>
        private void LaunchAuthMenu()
        {
            loginView = new LoginWindow();

            //loginView.Authenticated += isAuthenticated;
            loginView.Closing += loginViewIsClosed;

            //loginView.Show();
            loginView.ShowDialog();

            /*
             MODE DEBUG
             */
            //// Récupération de l'utilisateur Courant
            //context.Vendeur = new Vendeur() { Name ="ISitech Account"};

            //// Mise à jour du menu
            //headerAccountName.Header = context.Vendeur.Name;
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

        /// <summary>
        /// Fermeture de l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void MenuItemBouteille_Click(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine("CLICK");

            TabItem item = null;
            Grid grid = null;
            
            try
            {
                // Creating the Grid (create Canvas or StackPanel or other panel here)
                grid = new Grid() { HorizontalAlignment=HorizontalAlignment.Stretch, VerticalAlignment=VerticalAlignment.Stretch};

                grid.Children.Add(new BouteilleUserControl());

                item = new CloseableTabItem();
                item.Header = "Liste des Bouteilles";
                //item.Header = "Hello, this is the new tab item!";
                item.Content = grid;            // OR : Add a UserControl containing all controls you like, OR use a ContentTemplate

                tabControl.Items.Add(item);
                tabControl.SelectedItem = item;   // Setting focus to the new TabItem
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating the TabItem content! " + ex.Message);
            }
            finally
            {
                grid = null;
                item = null;
            }
            
        }
        
    }
}