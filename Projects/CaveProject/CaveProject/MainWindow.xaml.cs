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

            mainController = new MainController();

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

            /*
             MODE RELEASE
             */
            loginView.ShowDialog();

            /*
             MODE DEBUG
             */
            // Récupération de l'utilisateur Courant
            //context.Vendeur = new Vendeur() { Name = "Isitech Account" };

            // Mise à jour du menu
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
        /// Fermeture de l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        /// <summary>
        /// Afficher l'ensemble des Bouteilles de la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemBouteille_Click(object sender, RoutedEventArgs e)
        {
            this.OpenNewTab(new BouteilleUserControl(), "Liste des Bouteilles");
        }

        /// <summary>
        /// Afficher l'ensemble des Vendeurs de la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemVendeur_Click(object sender, RoutedEventArgs e)
        {
            this.OpenNewTab(new VendeurUserControl(), "Liste des Vendeurs");
        }

        /// <summary>
        /// Afficher l'ensemble des Clients de la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemClient_Click(object sender, RoutedEventArgs e)
        {
            this.OpenNewTab(new ClientUserControl(), "Liste des Clients");
        }

        /// <summary>
        /// Afficher l'ensemble des Commandes de la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemCommande_Click(object sender, RoutedEventArgs e)
        {
            // TODO
            //this.OpenNewTab(new CommandeUserControl(), "Liste des Commandes");
        }

        /// <summary>
        /// Ouvre un nouvel onglet dans le tabControl avec comme Contenu un UserControle et un Titre.
        /// </summary>
        /// <param name="aUserControl"></param>
        /// <param name="header"></param>
        private void OpenNewTab(UserControl aUserControl, String header)
        {
            TabItem item = null;
            Grid grid = null;

            try
            {
                // Creating the Grid (create Canvas or StackPanel or other panel here)
                grid = new Grid() { HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch };

                grid.Children.Add(aUserControl);

                item = new CloseableTabItem();
                item.Header = header;
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