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

namespace CaveProject.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// Gestion de l'Authentification du vendeur.
    /// </summary>
    public partial class LoginWindow : Window
    {
        private VendeurService oVendeurService;

        public event AuthenticatedHandler Authenticated;
        public EventArgs eventArgs = null;

        public delegate void AuthenticatedHandler(object m, EventArgs eventArgs);

        public LoginWindow()
        {
            InitializeComponent();

            oVendeurService = new VendeurService();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonConnect_Click(object sender, RoutedEventArgs e)
        {
            Vendeur leVendeur = new Vendeur();

            leVendeur.Login = loginBox.Text;

            leVendeur.Password = passwordBox.Password;

            IList<Vendeur> lstVendeur = oVendeurService.FindVendeur(leVendeur);

            Console.Out.WriteLine(lstVendeur.Count);

            // 
            //Authenticated(this, eventArgs);
        }
    }
}
