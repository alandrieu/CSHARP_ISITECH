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
    /// Formulaire de saisie qui permet la création d'un nouveau contact.
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
            newContact.Email = TextBoxEmail.Text;

            int age;
            bool test = Int32.TryParse(TextBoxAge.Text, out age);
            newContact.Age = age;
            //newContact.Age = Int32.Parse(TextBoxAge.Text);

            if (ComboBoxGender.SelectedValue != null)
            {
                ComboBoxItem item = (ComboBoxItem)ComboBoxGender.SelectedItem;
                newContact.Sexe = ParseEnum<Contact.SexeEnum>(item.Content.ToString());
            }

            newContact.Address = TextBoxAddress.Text;
            newContact.TelephoneNumber = TextBoxTelephoneNumber.Text;

            if (ComboBoxCountry.SelectedValue != null)
            {
                ComboBoxItem item = (ComboBoxItem)ComboBoxCountry.SelectedItem;
                newContact.Country = ParseEnum<Contact.CountryEnum>(item.Content.ToString());
            }

            newContact.OwnDescription = TextBoxOwnDescription.Text;

            // Social network account informations
            newContact.FaceBookAccount = TextBoxFaceBookAccount.Text;
            newContact.LinkedinAccount = TextBoxLinkedinAccount.Text;
            newContact.GooglePlusAccount = TextBoxGooglePlusAccount.Text;

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

        /// <summary>
        /// From String to Enum<T>
        /// Source : http://stackoverflow.com/questions/16100/how-do-i-convert-a-string-to-an-enum-in-c
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
