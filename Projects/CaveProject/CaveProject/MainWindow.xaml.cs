﻿using System;
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

namespace CaveProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Button> YourCollection { get; set; }

        public MainController mainController;

        public MainWindow()
        {
            InitializeComponent();

            YourCollection = new List<Button>();

            IDictionary<String, String> oCollection = new Dictionary<String, String>();

            oCollection.Add("Game", "");
            oCollection.Add("Google", "https://www.google.fr/images/srpr/logo11w.png");
            oCollection.Add("Vindictus", "http://www.google.fr/url?source=imglanding&ct=img&q=http://i.ytimg.com/vi/tyuPP0DSwnc/maxresdefault.jpg&sa=X&ei=N09tVd2QO4GwUYXggJgD&ved=0CAkQ8wc&usg=AFQjCNFmmay17iB-XVidfyBd9LVrGjr5Uw");
            oCollection.Add("Cortana", "http://www.google.fr/url?source=imglanding&ct=img&q=http://www.journaldugeek.com/wp-content/blogs.dir/1/files/2014/06/cortana.jpg&sa=X&ei=1E5tVfSiMcfnUurUgcAH&ved=0CAkQ8wc&usg=AFQjCNFJEGaiLKNAfgw0vIW28WrWJDTxTg");
            oCollection.Add("Google1", "http://www.google.fr/url?source=imglanding&ct=img&q=http://api.ning.com/files/58v-ee3J3CKynDP9SP5XWVzvdxL772zI2e2L4c7c8D6Ngtj8lHlRwqORTjPaxBcqCWvIW36Sjw*ZaU9Hhq5G0Kvl-kUR3LS8/google_logo.png&sa=X&ei=GnVsVbOnJYu9Ua22gMAI&ved=0CAkQ8wc&usg=AFQjCNGa__QmF1Kz4FIc77OoUwHtWlXMFg");
            oCollection.Add("Google2", "http://www.dotnetfoundation.org/Media/dotnet_logo.png");
            oCollection.Add("Google3", "http://www.mono-project.com/images/mono-gorilla.svg");
            oCollection.Add("Google_", "https://www.google.fr/images/srpr/logo11w.png");
            oCollection.Add("Vindictus_", "http://www.google.fr/url?source=imglanding&ct=img&q=http://i.ytimg.com/vi/tyuPP0DSwnc/maxresdefault.jpg&sa=X&ei=N09tVd2QO4GwUYXggJgD&ved=0CAkQ8wc&usg=AFQjCNFmmay17iB-XVidfyBd9LVrGjr5Uw");
            oCollection.Add("Cortana_", "http://www.google.fr/url?source=imglanding&ct=img&q=http://www.journaldugeek.com/wp-content/blogs.dir/1/files/2014/06/cortana.jpg&sa=X&ei=1E5tVfSiMcfnUurUgcAH&ved=0CAkQ8wc&usg=AFQjCNFJEGaiLKNAfgw0vIW28WrWJDTxTg");
            oCollection.Add("Google1_", "http://www.google.fr/url?source=imglanding&ct=img&q=http://api.ning.com/files/58v-ee3J3CKynDP9SP5XWVzvdxL772zI2e2L4c7c8D6Ngtj8lHlRwqORTjPaxBcqCWvIW36Sjw*ZaU9Hhq5G0Kvl-kUR3LS8/google_logo.png&sa=X&ei=GnVsVbOnJYu9Ua22gMAI&ved=0CAkQ8wc&usg=AFQjCNGa__QmF1Kz4FIc77OoUwHtWlXMFg");
            oCollection.Add("Google2_", "http://www.dotnetfoundation.org/Media/dotnet_logo.png");
            oCollection.Add("Google3_", "http://www.mono-project.com/images/mono-gorilla.svg");
            oCollection.Add("GPG", "https://www.gnupg.org/share/logo-gnupg-light-purple-bg.png");

            foreach (KeyValuePair<string, string> entry in oCollection)
            {
                // You could parse your XML and update the collection
                // Also implement INotifyPropertyChanged

                //Dummy Data for Demo 
                Button objButton = new Button() { Height = 40, Width = 105, Name = entry.Key, Content = entry.Key };

                objButton.Click += Button_Click;

                YourCollection.Add(objButton);
                //YourCollection.Add(new Button() { Height = 25, Width = 25 });
            }

            this.DataContext = this;

            mainController = new MainController();
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
    }
}