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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace wpfFirstApp.UserControls
{
    public sealed partial class FirstControl : UserControl
    {
        private Visibility isVisible;

        public FirstControl()
        {
            this.InitializeComponent();

            isVisible = Visibility.Visible;
        }

        public String scrPath;
        public String scrPath_defaultPicture = "http://www.google.fr/url?source=imglanding&ct=img&q=https://www.random.org/analysis/randbitmap-rdo.png&sa=X&ei=paFuVaHbI4bkUaSjgNAN&ved=0CAkQ8wc&usg=AFQjCNFxk2ArA2i63SYx9wlrSQ_j_nzqKQ";
        public Point pos;

        public FirstControl(String srcPath_, Point pos_)
            : this(srcPath_)
        {
            //this.scrPath = srcPath_;
            this.pos = pos_;

            this.Width = 100;
            this.Height = 100;
        }

        public FirstControl(String srcPath_)
            : this()
        {
            // Check srcPath
            //if (String.IsNullOrEmpty(srcPath_))
            //    myPicture.Source = new BitmapImage(new Uri("https://www.google.fr/images/srpr/logo11w.png"));
            //else
            //    myPicture.Source = new BitmapImage(new Uri(srcPath_));

            this.scrPath = srcPath_;

            //
            this.hideImage();
        }

        //public void hideImage(Boolean ishided)
        public void hideImage()
        {
            if (isVisible.Equals(Visibility.Collapsed))
            {
                 //oobjImg.Visibility = Visibility.Visible;
                 //myPicture.Visibility = Visibility.Visible;
                 isVisible = Visibility.Visible;
                 myPicture.Source = new BitmapImage(new Uri(this.scrPath));
            }
            else
            {
                //oobjImg.Visibility = Visibility.Collapsed;
                //myPicture.Visibility = Visibility.Collapsed;

                isVisible = Visibility.Collapsed;
                myPicture.Source = new BitmapImage(new Uri(this.scrPath_defaultPicture));
            }
        }
    }
}
