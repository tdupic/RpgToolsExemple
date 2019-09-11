using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RPGTools.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			InitializeComponent ();
            bttAbout.MinimumWidthRequest = bttReset.Width;
            bttHome.MinimumWidthRequest = bttReset.Width;
		}

        async private void About_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.DisplayAlert("A propos !", "Cette application vous est fournie par Coco l'asticoco, et Thipasbault !", "OK");
        }

        async private void Reset_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.DisplayAlert("Error !", "Not yet implemented", "OK");
        }

        private void Home_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}