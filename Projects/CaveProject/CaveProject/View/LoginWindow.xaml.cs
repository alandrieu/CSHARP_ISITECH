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
using System.Windows.Shapes;

using CaveLib.Bean;
using CaveLib.Service;
using CaveLib.Utils;

namespace CaveProject.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// Gestion de l'Authentification du vendeur.
    /// </summary>
    public partial class LoginWindow : Window
    {
        // Permet de récupréer les informations sur la base de données pour la table Vendeur
        private VendeurService oVendeurService;

        public Vendeur currentVendeur;

        public LoginWindow()
        {
            InitializeComponent();

            oVendeurService = new VendeurService();

            this.Icon = new BitmapImage(new Uri("./Ressources/shieldLoginForm.ico", UriKind.Relative));
        }

        /// <summary>
        /// Fermeture de l'application d'identification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Lors d'une tentative de connexion, on vérifi les identifiants de l'utilisateur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonConnect_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(loginBox.Text) || String.IsNullOrEmpty(passwordBox.Password))
                return;

            Vendeur leVendeur = new Vendeur();

            leVendeur.Login = loginBox.Text;

            leVendeur.Password = Hashing.SHA512(passwordBox.Password);

            IList<Vendeur> lstVendeur = oVendeurService.FindVendeur(leVendeur);

            // Debug
            Console.Out.WriteLine(lstVendeur.Count);

            if(lstVendeur.Count == 1)
            {
                currentVendeur = lstVendeur.ElementAt<Vendeur>(0);
                this.Close();
            }
            else
            {
                loginBox.Foreground = Brushes.Red;
                passwordBox.Foreground = Brushes.Red;
            }
        }
    }
}
