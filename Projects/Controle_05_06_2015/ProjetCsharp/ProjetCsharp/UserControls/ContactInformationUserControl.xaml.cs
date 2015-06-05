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
    /// Interaction logic for ContactInformationUserControl.xaml
    /// Afficher les informations d'un Contact
    /// </summary>
    public partial class ContactInformationUserControl : UserControl
    {

        public event RemoveHandler RemoveMe;
        public delegate void RemoveHandler(ContactInformationUserControl userControl, EventArgs e);

        public ContactInformationUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Construire un formulaire d'information sur un contact,
        /// Mapping manuel des Informations du contact dans la vue XAML.
        /// </summary>
        /// <param name="contact"></param>
        public ContactInformationUserControl(Contact contact)
            : this()
        {
            TextBlockId.Text = contact.Id.ToString();

            TextBlockNom.Text = contact.Nom;
            TextBlockPrenom.Text = contact.Prenom;
            TextBlockAge.Text = contact.Age.ToString();

            TextBlockEmail.Text = contact.Email;

            TextBlockSexe.Text = contact.Sexe.ToString();

            TextBlockTelephoneNumber.Text = contact.TelephoneNumber;

            TextBlockCountry.Text = contact.Country.ToString();

            // Traitement des Liens vers les réseaux sociaux
            
            //TextBlockFaceBookAccount.Text = contact.FaceBookAccount;
            //TextBlockGooglePlusAccount.Text = contact.GooglePlusAccount;
            //TextBlockLinkedinAccount.Text = contact.LinkedinAccount;

            try
            {
                HyperLinkFaceBookAccount.RequestNavigate += Hyperlink_RequestNavigate;
                HyperLinkFaceBookAccount.NavigateUri = new Uri(contact.FaceBookAccount);

                HyperLinkGooglePlusAccount.RequestNavigate += Hyperlink_RequestNavigate;
                HyperLinkGooglePlusAccount.NavigateUri = new Uri(contact.GooglePlusAccount);

                HyperLinkLinkedinAccount.RequestNavigate += Hyperlink_RequestNavigate;
                HyperLinkLinkedinAccount.NavigateUri = new Uri(contact.LinkedinAccount);
            }
            catch (Exception ex)
            {
                // TODO
            }
        }

        /// <summary>
        /// Demander la suppression d'un contact
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            // Send event remove
            RemoveMe(this, e);
        }

        /// <summary>
        /// Ouvrir le naviguateur à l'URL définie dans l'hyperlien
        /// Source : http://stackoverflow.com/questions/531621/how-to-make-a-simple-hyperlink-in-xaml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Hyperlink hyperLink = (Hyperlink)sender;

            System.Diagnostics.Process.Start(hyperLink.NavigateUri.AbsoluteUri);
        }
    }
}
