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

using ProjectCsharpLib.Bean;
using ProjetCsharp.UserControls;

namespace ProjetCsharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Interface Principal.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Initialisation du XAML
            InitializeComponent();

            // Initialisation des composants
            InitializeComponentMainWindows();
        }

        /// <summary>
        /// Initialisation des composants de notre XAML
        /// </summary>
        void InitializeComponentMainWindows()
        {
            ContactFormUserControl userControl = new UserControls.ContactFormUserControl();

            userControl.AValide += ContactFromControl_AValide;

            myInputContainer.Children.Add(userControl);
        }

        /// <summary>
        /// Ajouter le nouveau contact dans la vue. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactFromControl_AValide(object sender, EventArgs e)
        {
            Contact newContact = (Contact)sender;

            // Ajouter une entrer dans la liste
            myOutputContainer.Children.Add(new ContactInformationUserControl(newContact));
        }
    }
}
