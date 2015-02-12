using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinNativeFacebook
{
    public partial class DiplayTokenPage : ContentPage
    {
        public DiplayTokenPage(string token)
        {
            InitializeComponent();
            this.Content = new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text = token
                    }
                }
            };
        }
    }
}
