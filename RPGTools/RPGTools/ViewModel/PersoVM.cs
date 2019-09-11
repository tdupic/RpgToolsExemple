using BiblioJdr;
using BiblioJdr.metier;
using RPGTools.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RPGTools.ViewModel
{
    public class PersoVM : BaseViewModel
    {
        private Personnage model_;

        private string name_;
        public string Name
        {
            get => name_;
            set => SetValue(ref name_, value);
        }

        private int level_;
        public int Level
        {
            get => level_;
            set => SetValue(ref level_, value);
        }

        private int po_;
        public int Po
        {
            get => po_;
            set => SetValue(ref po_, value);
        }

        private int xpEnCour_;
        public int XpEnCour
        {
            get => xpEnCour_;
            set => SetValue(ref xpEnCour_, value);
        }

        private int xpMax_;
        public int XpMax
        {
            get => xpMax_;
            set => SetValue(ref xpMax_, value);
        }

        public string Xp
        {
            get => XpEnCour + "/" + XpMax;
        }
            

        private string classe_;
        public string Classe
        {
            get => classe_;
            set => SetValue(ref classe_, value);
        }

        private StatVM selectedStat_;
        public StatVM SelectedStat
        {
            get => selectedStat_;
            set
            {
                if(selectedStat_ != null) selectedStat_.ColorCell = Color.GhostWhite;
                SetValue(ref selectedStat_, value);
                selectedStat_.ColorCell = Color.Coral;
            }
        }

        private SortsVM selectedSort_;
        public SortsVM SelectedSort
        {
            get => selectedSort_;
            set => SetValue(ref selectedSort_, value);
        }

        private ItemVM selectedItem_;
        public ItemVM SelectedItem
        {
            get => selectedItem_;
            set => SetValue(ref selectedItem_, value);
        }

        private ObservableCollection<StatVM> listStats_;
        public ObservableCollection<StatVM>ListStats
        {
            get => listStats_;
            set => SetValue(ref listStats_, value);
        }

        private ObservableCollection<ItemVM> inventaire_;
        public ObservableCollection<ItemVM> Inventaire
        {
            get => inventaire_;
            set => SetValue(ref inventaire_, value);
        }

        private ObservableCollection<SortsVM> spells_;
        public ObservableCollection<SortsVM> Spells
        {
            get => spells_;
            set => SetValue(ref spells_, value);
        }

        private ItemVM armeEquipe_;
        public ItemVM ArmeEquipe
        {
            get => armeEquipe_;
            set => SetValue(ref armeEquipe_, value);
        }

        private ItemVM armureEquipe_;
        public ItemVM ArmureEquipe
        {
            get => armureEquipe_;
            set => SetValue(ref armureEquipe_, value);
        }

        public ICommand UpgradeStatCommand { get; private set; }
        public ICommand DowngradeStatCommand { get; private set; }
        public ICommand ItemTappedCommand { get; private set; }
        public ICommand AddItemCmd { get; private set; }
        public ICommand SortTappedCommand { get; private set; }
        public ICommand AddSpeelCmd { get; private set; }

        public PersoVM(Personnage inModel)
        {
            model_ = inModel;
            Name = model_.Nom;
            Classe = model_.Classe;
            Po = model_.Po;
            XpEnCour = model_.XpEnCours;
            XpMax = model_.XpMax;
            Level = model_.Level;
            ListStats = new ObservableCollection<StatVM>();
            Inventaire = new ObservableCollection<ItemVM>();
            Spells = new ObservableCollection<SortsVM>();
            foreach (Stat stat in model_.ROCStats)
            {
                ListStats.Add(new StatVM(stat));
            }
            foreach (Item item in model_.ROCInventaire)
            {
                Inventaire.Add(new ItemVM(item));
            }
            foreach(Sort sort in model_.ROCSorts)
            {
                Spells.Add(new SortsVM(sort));
            }
            InitCommand();
        }


        public PersoVM(List<Entry>inListClassicStats, Dictionary<Entry, Entry>inListNewStats)
        {
            model_ = new Personnage(inListClassicStats[0].Text, inListClassicStats[1].Text, 0);
            InitCommand();

            Name = model_.Nom;
            Classe = model_.Classe;
            Po = 0;
            XpEnCour = 0;
            XpMax = 10;
            Level = 1;

            ListStats = new ObservableCollection<StatVM>();
            Inventaire = new ObservableCollection<ItemVM>();
            Spells = new ObservableCollection<SortsVM>();
            ListStats.Add(new StatVM("PV", int.Parse(inListClassicStats[2].Text)));
            ListStats.Add(new StatVM("Force", int.Parse(inListClassicStats[3].Text)));
            ListStats.Add(new StatVM("Agilité", int.Parse(inListClassicStats[4].Text)));
            ListStats.Add(new StatVM("Inteligence", int.Parse(inListClassicStats[5].Text)));
            ListStats.Add(new StatVM("Charisme", int.Parse(inListClassicStats[6].Text)));
            foreach(Entry entry in inListNewStats.Keys)
            {
                ListStats.Add(new StatVM(entry.Text, int.Parse(inListNewStats[entry].Text)));
            }
            foreach(StatVM statsVm in ListStats)
            {
                model_.AjouterStat(statsVm.GetModel());
            }

        }

        private void InitCommand()
        {
            UpgradeStatCommand = new Command(ClickUpgradeStat);
            DowngradeStatCommand = new Command(ClickDowngradeStat);
            ItemTappedCommand = new Command(ClickOnItem);
            AddItemCmd = new Command(ClickOnAddItem);
            SortTappedCommand = new Command(clickOnSpell);
            AddSpeelCmd = new Command(ClickOnAddSpell);
        }

        private void ClickOnItem()
        {
            SelectedItem.SetProp(this);
            App.Current.MainPage.Navigation.PushAsync(new ItemDetailPage(SelectedItem));
        }

        private void ClickUpgradeStat()
        {
            if (SelectedStat != null)
            {
                SelectedStat.Upgrade();
            }
        }

        private void ClickDowngradeStat()
        {
            if (SelectedStat != null)
            {
                SelectedStat.Downgrade();
            }
        }

        private void ClickOnAddItem()
        {
            App.Current.MainPage.Navigation.PushAsync(new AddItemPage(this));
        }

        private void clickOnSpell()
        {
            App.Current.MainPage.Navigation.PushAsync(new SpellDetailPage(SelectedSort));
        }

        private void ClickOnAddSpell()
        {
            App.Current.MainPage.DisplayAlert("Error !", "Not yet implemented...", "OK");
        }
    }
}
