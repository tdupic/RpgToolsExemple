using BiblioJdr;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RPGTools.ViewModel
{
    public class SortsVM : BaseViewModel
    {
        private string nom_;
        public string Nom
        {
            get => nom_;
            set => SetValue(ref nom_, value);
        }

        private string effet_;
        public string Effet
        {
            get => effet_;
            set => SetValue(ref effet_, value);
        }

        private int montantDommage_;
        public int MontantDommage
        {
            get => montantDommage_;
            set => SetValue(ref montantDommage_, value);
        }

        private int coutMana_;
        public int CoutMana
        {
            get => coutMana_;
            set => SetValue(ref coutMana_, value);
        }

        private int cooldown_;
        public int Cooldown
        {
            get => cooldown_;
            set => SetValue(ref cooldown_, value);
        }

        private Sort model_;
        public Sort Model
        {
            get => model_;
            set => SetValue(ref model_, value);
        }

        public ICommand UseSpellCmd { get; private set; }

        public SortsVM(Sort model_)
        {
            Model = model_;
            Nom = model_.Nom;
            Effet = Model.Effet;
            MontantDommage = Model.MontantDommage;
            CoutMana = Model.CoutMana;

            UseSpellCmd = new Command(ClickOnUseSpell);
        }

        private void ClickOnUseSpell()
        {
            App.Current.MainPage.DisplayAlert("Information", "Le mana se rassemble autour du personnage, le sort est lancé ! Mais rien ne se passe...", "OK");
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
