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
using System.Text.RegularExpressions;

namespace ProjetCsharp.UserControls
{
    /// <summary>
    /// Interaction logic for ContactFormUserControl.xaml
    /// </summary>
    public partial class ContactFormUserControl : UserControl
    {
        public event ValiderHandler AValide;
        public delegate void ValiderHandler(Contact contact, EventArgs e);


        public ContactFormUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Valider Le nouveau contact
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonValider_Click(object sender, RoutedEventArgs e)
        {
            Contact newContact = new Contact();

            // Récupération des informations du formulaire
            newContact.Nom = TextBoxName.Text;
            newContact.Prenom = TextBoxPrenom.Text;


            // Informer la fin de saisie
            AValide(newContact, e);
        }

        /// <summary>
        /// TextBox with only Int input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
    }
}
