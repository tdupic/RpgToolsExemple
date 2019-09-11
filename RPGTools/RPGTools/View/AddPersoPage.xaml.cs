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
	public partial class AddPersoPage : ContentPage
    {
        Dictionary<Entry, Entry>newStatsList = new Dictionary<Entry, Entry>();

		public AddPersoPage ()
		{
			InitializeComponent ();
		}

        async private void Valider_Clicked(object sender, EventArgs e)
        {
            //errorLbl.IsVisible = false;
            if (CheckEntryValue())
            {
                List<Entry> classicStats = new List<Entry>();
                classicStats.Add(txtName);
                classicStats.Add(txtClasse);
                classicStats.Add(txtPv);
                classicStats.Add(txtForce);
                classicStats.Add(txtAgi);
                classicStats.Add(txtIntel);
                classicStats.Add(txtChar);
                App.Current.MainPage = new NavigationPage(new MainMenuPage(classicStats, newStatsList));
            }

            else
            {
                await App.Current.MainPage.DisplayAlert("Error !", "A field is empty...", "OK");
                //errorLbl.IsVisible = true;
            }
        }

        private bool CheckEntryValue()
        {
            bool check = false;
            if (txtName.Text != "" && txtClasse.Text != "" && txtForce.Text != "" && txtPv.Text != "" && txtAgi.Text != "" && txtIntel.Text != "" && txtChar.Text != "")
            {
                check = true;
                foreach (Entry entry in newStatsList.Keys)
                {
                    if (entry.Text == "" && newStatsList[entry].Text == "" )
                    {
                        check = false;
                    }
                }
            }
            return check;
        }

        private void AddStats_Clicked(object sender, EventArgs e)
        {
            Entry statName = new Entry();
            Entry statValue = new Entry();
            statName.Text = "";
            statValue.Text = "";
            statValue.Keyboard = Xamarin.Forms.Keyboard.Numeric;
            statValue.MaxLength = 2;
            int nbRow = gridStat.Children.Count/2;
            gridStat.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            gridStat.Children.Add(statName, 0, nbRow);
            gridStat.Children.Add(statValue, 1, nbRow);
            newStatsList.Add(statName, statValue);
            scrollView.ScrollToAsync(0, addStatBtt.Y, true);
        }
    }
}