using System.Collections.Generic;
using BiblioJdr.metier;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RPGTools.UserControls;
using System.Diagnostics;

namespace RPGTools.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadPersoPage : ContentPage
	{
        List<Personnage> persos_;//= new List<Personnage>();
		public LoadPersoPage()
		{
			InitializeComponent();
            LoadPersonnagesFromBd();
		}
        public void LoadPersonnagesFromBd()
        {
            //JdrDBManager manager = new JdrDBManager(false);
           // persos_ = BPersistance.Stub.LesPerso();// App.dBManager.GetPersonnageAsync().Result;
            persos_ = BPersistance.Stub.LesPersoStatsInventaire();
            GenerateUCBTForPersos();
        }
        public void GenerateUCBTForPersos()
        {
            foreach(Personnage p in persos_)
            {
                UCBTLoadPerso test = new UCBTLoadPerso
                {
                    Name = p.Nom,
                    Level = "Level " + p.Level,
                    BackgroundColor = Color.LightGray,
                    HeightRequest = 75,
                    WidthRequest = 150
                };
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) =>
                {
                    App.Current.MainPage = new NavigationPage(new MainMenuPage(p));
                };
                test.GestureRecognizers.Add(tapGestureRecognizer);
                StackLayoutLoad.Children.Add(test);
            }
        }
    }
}