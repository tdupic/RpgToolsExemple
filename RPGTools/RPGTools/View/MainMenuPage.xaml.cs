using RPGTools.ViewModel;
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
	public partial class MainMenuPage : TabbedPage
    {
		public MainMenuPage (List<Entry> classicStats, Dictionary<Entry, Entry> newStatsList)
		{
			InitializeComponent ();
            PersoVM personnage = new PersoVM(classicStats, newStatsList);

            InitChildInTab(personnage);
        }

        public MainMenuPage(BiblioJdr.metier.Personnage p)
        {
            InitializeComponent();
            PersoVM personnage = new PersoVM(p);

            InitChildInTab(personnage);
        }

        private void InitChildInTab(PersoVM personnage)
        {
            var inventaireNavigationPage = new InventairePage(personnage);

            var personnageNavigationPage = new PersonnagePage(personnage);

            ListeSortsPage sortNavigationPage = new ListeSortsPage(personnage);

            DicePage diceNavigationPage = new DicePage();

            Children.Add(personnageNavigationPage);
            Children[0].Title = "Personnage";
            Children.Add(inventaireNavigationPage);
            Children[1].Title = "Inventaire";
            Children.Add(sortNavigationPage);
            Children[2].Title = "Sorts";
            Children.Add(diceNavigationPage);
            Children[3].Title = "Dés";
        }

        private void Option_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }
    }
}