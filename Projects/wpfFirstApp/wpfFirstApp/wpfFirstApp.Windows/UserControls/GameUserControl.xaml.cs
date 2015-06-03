using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

//using Windows.UI.Xaml.DispatcherTimer;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace wpfFirstApp.UserControls
{
    public sealed partial class GameUserControl : UserControl
    {
        // Liste des contrôles du Grid - grid01
        IList<FirstControl> lstControl;

        private static DispatcherTimer dispatcherTimer;

        private int intNbCoup = 0;
        private int gamestateEnd = 0;
        private int gamestate = 0;

        // Buffer sur les images en cours de traitements
        private FirstControl firstImg;
        private FirstControl SecondImg;

        public GameUserControl()
        {
            this.InitializeComponent();

            lstControl = new List<FirstControl>();

            this.CreateTImer();

            gamestateEnd = (gri01.RowDefinitions.Count * gri01.ColumnDefinitions.Count) / 2;
            this.Refresh();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            this.Refresh();
        }

        private void Clear()
        {
            gri01.Children.Clear();
            intNbCoup = 0;
            UpdateScore();
            lstControl.Clear();

            gamestate = 0;
        }

        private void Refresh()
        {
            // TODO clear and change IMAGE
            this.Clear();

            IList<String> oCollectionImg = new List<String>();

            //oCollectionImg.Add("https://www.google.fr/images/srpr/logo11w.png");
            //oCollectionImg.Add("http://www.google.fr/url?source=imglanding&ct=img&q=http://i.ytimg.com/vi/tyuPP0DSwnc/maxresdefault.jpg&sa=X&ei=N09tVd2QO4GwUYXggJgD&ved=0CAkQ8wc&usg=AFQjCNFmmay17iB-XVidfyBd9LVrGjr5Uw");
            //oCollectionImg.Add("http://www.google.fr/url?source=imglanding&ct=img&q=http://www.journaldugeek.com/wp-content/blogs.dir/1/files/2014/06/cortana.jpg&sa=X&ei=1E5tVfSiMcfnUurUgcAH&ved=0CAkQ8wc&usg=AFQjCNFJEGaiLKNAfgw0vIW28WrWJDTxTg");
            //oCollectionImg.Add("http://www.google.fr/url?source=imglanding&ct=img&q=http://api.ning.com/files/58v-ee3J3CKynDP9SP5XWVzvdxL772zI2e2L4c7c8D6Ngtj8lHlRwqORTjPaxBcqCWvIW36Sjw*ZaU9Hhq5G0Kvl-kUR3LS8/google_logo.png&sa=X&ei=GnVsVbOnJYu9Ua22gMAI&ved=0CAkQ8wc&usg=AFQjCNGa__QmF1Kz4FIc77OoUwHtWlXMFg");
            oCollectionImg.Add("http://www.dotnetfoundation.org/Media/dotnet_logo.png");
            //oCollectionImg.Add("http://www.google.fr/url?source=imglanding&ct=img&q=http://bathzone.co/wp-content/uploads/2013/09/KDP-7.jpg&sa=X&ei=EZxtVamROoriUd-qgLgH&ved=0CAkQ8wc&usg=AFQjCNEuE-ZGSdHcuu0cQfZ49Chyv5E3Ow");
            //oCollectionImg.Add("http://www.google.fr/url?source=imglanding&ct=img&q=http://www.marble-mosaics.com/ekmps/shops/marblemosaics/resources/Image/light-travertine-tile.jpg&sa=X&ei=wJxtVeCjCcHXU8rAgqAK&ved=0CAkQ8wc&usg=AFQjCNGOaO4h8g2eBLHriC-iDSLs349bCg");
            oCollectionImg.Add("http://www.dofactory.com/images/logo-new2.png");
            oCollectionImg.Add("http://www.google.fr/url?source=imglanding&ct=img&q=http://lactutechno.com/wp-content/uploads/2015/03/Halo_5-masterchief-hunt-the-truth-tumblr.jpg&sa=X&ei=5JpuVZXFEMzeUeOqgtgG&ved=0CAkQ8wc&usg=AFQjCNFxmQ_gQljsE8zXhpUSrMNuS2KrFQ");
            oCollectionImg.Add("http://www.google.fr/url?source=imglanding&ct=img&q=http://img1.wikia.nocookie.net/__cb20130610202418/video151/images/7/70/Official_E3_2013_Halo_Teaser_for_the_Xbox_One&sa=X&ei=FZtuVZu3HYGwUYXggJgD&ved=0CAkQ8wc4Cg&usg=AFQjCNHF4wvj_mSelinr9wXtowrTy6FlSg");
            oCollectionImg.Add("http://www.google.fr/url?source=imglanding&ct=img&q=http://i.jeuxactus.com/datas/jeux/t/h/the-legend-of-zelda-spirit-tracks/xl/the-legend-of-zelda-4e26529e14664.jpg&sa=X&ei=VZtuVfp-y_BS-LeC4Ao&ved=0CAkQ8wc&usg=AFQjCNGbPcaoAxApWp2Bjp3XYZq8S8BH_w");
            oCollectionImg.Add("http://www.google.fr/url?source=imglanding&ct=img&q=http://www.journaldugeek.com/wp-content/blogs.dir/1/files/2015/05/sony-sort-l-artillerie-lourde1.jpg&sa=X&ei=YJtuVYeQB4HaUr-vgXg&ved=0CAkQ8wc&usg=AFQjCNE_pMeb_Cc4EsP5xVWyFLeIYpm32Q");
            oCollectionImg.Add("http://www.google.fr/url?source=imglanding&ct=img&q=https://cdn03.nintendo-europe.com/media/images/03_teaser_module_1_square/news_1/generic/TM_NintendoLogo_sharing_image_400.png&sa=X&ei=bJtuVfOwC8fWUdSMgfgC&ved=0CAkQ8wc&usg=AFQjCNEisULJabRE9FSt68dVULQMnORGlA");
            oCollectionImg.Add("http://www.google.fr/url?source=imglanding&ct=img&q=http://static1.gamespot.com/uploads/original/1179/11799911/2860011-sega1.jpg&sa=X&ei=tJtuVcnTHMX_UvCZg_AB&ved=0CAkQ8wc&usg=AFQjCNF-2lAeXrL8BFUe1GxxL2D7fC729Q");

            int cpt = 0;

            Random rnd = new Random();

            //  Parcours du Grid (4x4)
            for (int y = 0; y < gri01.RowDefinitions.Count; y++)
            {
                for (int x = 0; x < gri01.ColumnDefinitions.Count; x++)
                {
                    //String newObject = oCollectionImg.ElementAt<String>(cpt);
                    //lstControl.Add(new FirstControl(newObject, new Point(i1, y)));
                    //cpt++;

                    int exist = 0;

                    // Tant qu'un élément n'est pas ajouté dans le boutton
                    int indexAddElement = rnd.Next(0, oCollectionImg.Count);

                    String sourceImage = oCollectionImg.ElementAt<String>(indexAddElement);

                    foreach (FirstControl objImg in lstControl)
                    {
                        if (objImg.scrPath == sourceImage)
                            exist++;
                    }

                    // Si la Collection d'image est vide
                    if (oCollectionImg.Count == 0)
                    {
                        return;
                    }
                    else
                    {
                        lstControl.Add(new FirstControl(sourceImage, new Point(x, y)));

                        if(exist >= 1)
                            oCollectionImg.RemoveAt(indexAddElement);
                    }
                }
            }

            // Injection des UserControls dans le grid
            foreach (FirstControl objImg in lstControl)
            {
                Grid.SetRow(objImg, (int)objImg.pos.Y);
                Grid.SetColumn(objImg, (int)objImg.pos.X);

                gri01.Children.Add(objImg);

                objImg.Tapped += Button_Click;
            }
        }

        /// <summary>
        /// Sur l'événement Tapped du UserControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (firstImg != null && SecondImg != null)
                return;

            FirstControl oobjImg = (FirstControl)sender;

            intNbCoup++;

            UpdateScore();

            oobjImg.hideImage();

            ClickImg(oobjImg);

            this.checkEndGame();
        }

        /// <summary>
        /// Affiche un message spécial quand la partie est finie
        /// </summary>
        private void checkEndGame()
        {
            if(this.gamestate >= this.gamestateEnd)
            {
                score.Text = "SCORE :" + intNbCoup.ToString() + ", Clear to restart a new game";
            }
        }

        /// <summary>
        /// Mettre à jour le score dans la TexteBox
        /// </summary>
        private void UpdateScore()
        {
            score.Text = "SCORE :" + intNbCoup.ToString();
        }

        /// <summary>
        /// Création du Timer
        /// </summary>
        private void CreateTImer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(2);
            dispatcherTimer.Tick += timer_Tick;
        }
        /// <summary>
        /// Traitement d'un Click sur une Image
        /// </summary>
        /// <param name="object_"></param>
        private void ClickImg(FirstControl object_)
        {
            if (firstImg == null)
            {
                firstImg = object_;
            }
            else if (SecondImg == null)
            {
                SecondImg = object_;


                // SI pas egale on retourne.
                if (!firstImg.scrPath.Equals(SecondImg.scrPath))
                {
                    //  DispatcherTimer setup
                    dispatcherTimer.Start();

                    //firstImg.hideImage();
                    //SecondImg.hideImage();
                }
                else
                {
                    gamestate++;
                    firstImg = null;
                    SecondImg = null;
                }
            }
            else
            {

            }
        }

        private void timer_Tick(object sender, object e)
        {
            firstImg.hideImage();
            SecondImg.hideImage();

            firstImg = null;
            SecondImg = null;

            dispatcherTimer.Stop();
        }
    }
}
