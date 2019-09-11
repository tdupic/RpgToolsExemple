using System;
using BiblioJdr;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RPGTools.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DicePage : ContentPage
	{
        public DicePage ()
		{
			InitializeComponent ();
		}
        
        async void OnEntryTapped(object sender, EventArgs args)
        {
            await App.Current.MainPage.DisplayAlert("Resultat", Dice.lancerDe(int.Parse(persoDice.Text)).ToString(), "Ok");
        }

        async void OnTapGestureDice6Async(object sender, EventArgs args)
        {
            await App.Current.MainPage.DisplayAlert("Resultat", Dice.lancerDe(6).ToString(), "Ok");
        }

        async void OnTapGestureDice10Async(object sender, EventArgs args)
        {
            await App.Current.MainPage.DisplayAlert("Resultat", Dice.lancerDe(10).ToString(), "Ok");
        }

        async void OnTapGestureDice20Async(object sender, EventArgs args)
        {
            await App.Current.MainPage.DisplayAlert("Resultat", Dice.lancerDe(20).ToString(), "Ok");
        }

        async void OnTapGestureDice100Async(object sender, EventArgs args)
        {
            await App.Current.MainPage.DisplayAlert("Resultat", Dice.lancerDe(100).ToString(), "Ok");
        }
    }
}