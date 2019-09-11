using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RPGTools.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private void OnClickNouveau(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddPersoPage());
        }

        private void OnClickCharger(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoadPersoPage());
        }
    }
}
