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
    /// 
    /// Afficher les informations d'un Contact
    /// </summary>
    public partial class ContactInformationUserControl : UserControl
    {
        public ContactInformationUserControl()
        {
            InitializeComponent();
        }

        public ContactInformationUserControl(Contact contact): this()
        {
            TextBlockPrenom.Text = contact.Name;

        }
    }
}
