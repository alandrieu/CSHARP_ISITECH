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
            newContact.Name = TextBoxName.Text;


            // Informer la fin de saisie
            AValide(newContact, e);
        }
    }
}
