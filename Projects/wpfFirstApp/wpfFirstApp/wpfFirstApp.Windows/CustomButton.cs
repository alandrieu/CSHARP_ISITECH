using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfFirstApp
{
    class CustomButton : Windows.UI.Xaml.Controls.Button
    {
        public String imgReference;

        public CustomButton(String src) : base()
        {
            this.imgReference = src;
        }
    }
}
