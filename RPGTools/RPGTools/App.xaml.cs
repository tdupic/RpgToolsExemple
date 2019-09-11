using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RPGTools.View;
using BPersistance.bdd;
using BiblioJdr.outils;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace RPGTools
{
    public partial class App : Application
    {
        public static IDataManager dBManager;
        public App()
        {
            InitializeComponent();
            //TODO : fix l'instanciation pour utiliser une base de données
            //dBManager = new JdrDBManager(false);
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
