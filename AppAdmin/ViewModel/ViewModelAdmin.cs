using AppAdmin.Services;
using AppAdmin.View;
using BiblioJdr;
using BiblioJdr.metier;
using BPersistance;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace AppAdmin.ViewModel
{
    public class ViewModelAdmin : BaseViewModel
    {
        public ICommand CmdDisconnect { get; set; }
        public ICommand CmdQuit { get; set; }
        public ICommand CmdList { get; set; }

        public ICommand CmdAddPerso { get; set; }
        public ICommand CmdAddItem { get; set; }

        public ICommand CmdAddNewPerso { get; set; }
        public ICommand CmdAddNewItem { get; set; }

        public ObservableCollection<PlayerVM> ListPlayer { get; private set; }
        public ObservableCollection<ItemsVM> ListItems { get; private set; }


        //Shared
        private string _nom;
        public string Nom
        {
            get => _nom;
            set => SetValue(ref _nom, value);
        }

        //Player
        private string _classe;
        public string Classe
        {
            get => _classe;
            set => SetValue(ref _classe, value);
        }

        private int _level;
        public int Level
        {
            get => _level;
            set => SetValue(ref _level, value);
        }

        //Items
        private int _mttDmg;
        public int MttDmg
        {
            get => _mttDmg;
            set => SetValue(ref _mttDmg, value);
        }

        private string _effet;
        public string Effet
        {
            get => _effet;
            set => SetValue(ref _effet, value);
        }

        private bool[] _typeItem = new bool[] { false, false, false, false };
        public bool[] TypeItem
        {
            get => _typeItem;
            set => SetValue(ref _typeItem, value);
  
        }

        public ViewModelAdmin()
        {
            CmdDisconnect = new RelayCommand(ClickDisconnect);
            CmdQuit = new RelayCommand(ClickQuit);
            CmdAddPerso = new RelayCommand(ClickAddPerso);
            CmdAddItem = new RelayCommand(ClickAddItem);
            CmdList = new RelayCommand(ClickList);
            CmdAddNewPerso = new RelayCommand(ClickAddNewPersoAsync);
            CmdAddNewItem = new RelayCommand(ClickAddNewItemsAsync);
            ListPlayer = new ObservableCollection<PlayerVM>();
            ListPlayerInit();
            ListItems = new ObservableCollection<ItemsVM>();
            ListItemsInit();
        }

        private async void ClickAddNewItemsAsync()
        {
            bool verifEmptyArmeArmure = ((Nom != "") && (MttDmg >= 0) && (Effet != ""));
            bool verifEmptyPotion = ((Nom != "") && (Effet != ""));
            if (TypeItem[0] && verifEmptyArmeArmure)
            {
                ListItems.Add(new ItemsVM(new Arme(Nom, MttDmg, Effet, 1)));
                await new MessageDialog("Nom : " + Nom + " Dmg : " + MttDmg + " Effet : " + Effet).ShowAsync();
                Nom = "";
                MttDmg = 0;
                Effet = "";
                Frame frame = (Frame)Window.Current.Content;
                frame.Navigate(typeof(ViewAdmin), this);
            }
            else if (TypeItem[1] && verifEmptyArmeArmure)
            {
                ListItems.Add(new ItemsVM(new Armure(Nom, MttDmg, Effet, 1)));
                await new MessageDialog("Nom : " + Nom + " Dmg : " + MttDmg + " Effet : " + Effet).ShowAsync();
                Nom = "";
                MttDmg = 0;
                Effet = "";
                Frame frame = (Frame)Window.Current.Content;
                frame.Navigate(typeof(ViewAdmin), this);
            }
            else if (TypeItem[2] && verifEmptyPotion)
            {
                ListItems.Add(new ItemsVM(new Potion(Nom, Effet, 1)));
                await new MessageDialog("Nom : " + Nom + " Effet : " + Effet).ShowAsync();
                Nom = "";
                MttDmg = 0;
                Effet = "";
                Frame frame = (Frame)Window.Current.Content;
                frame.Navigate(typeof(ViewAdmin), this);
            }
            else if (TypeItem[3] && Nom!="")
            {
                ListItems.Add(new ItemsVM(new Nouriture(Nom, 1)));
                await new MessageDialog("Nom : " + Nom).ShowAsync();
                Nom = "";
                MttDmg = 0;
                Effet = "";
                Frame frame = (Frame)Window.Current.Content;
                frame.Navigate(typeof(ViewAdmin), this);
            }
            else
            {
                await new MessageDialog("Erreur, un champ n'est pas remplis").ShowAsync();
            }
        }

        private async void ClickAddNewPersoAsync()
        {
            bool testEmpty = ((Nom != "") && (Classe != "") && (Level >= 0));
            if (testEmpty)
            {
                await new MessageDialog("Nom : " + Nom + " Classe : " + Classe + " Level : " + Level).ShowAsync();
                ListPlayer.Add(new PlayerVM(new Personnage(Nom, Classe, 0, new Arme("", 0, "", 0), new Armure("", 0, "", 0))));
                Nom = "";
                Classe = "";
                Level = 0;
                Frame frame = (Frame)Window.Current.Content;
                frame.Navigate(typeof(ViewAdmin), this);
            }
            else
            {
                await new MessageDialog("Erreur, un champ n'est pas remplis").ShowAsync();
            }

        }

        private void ClickList()
        {
            Frame currentFrame = (Frame)Window.Current.Content;
            if (currentFrame.CanGoBack)
            {
                currentFrame.GoBack();
            }
        }

        private void ClickAddItem()
        {
           Frame frame = (Frame)Window.Current.Content;
           frame.Navigate(typeof(ViewAddItem), this);
        }

        private void ClickAddPerso()
        {
            Frame frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(ViewAddPerso), this);
        }

        private void ClickQuit()
        {
            App.Current.Exit();
        }

        internal void DeleteSelection(int id, Type type)
        {
            if(type == typeof(PlayerVM))
            {
                ListPlayer.RemoveAt(id);
            }
            else if(type == typeof(ItemsVM))
            {
                ListItems.RemoveAt(id);
            }
        }

        public void ListPlayerInit()
        {
            foreach(Personnage p in Stub.LesPerso())
            {
                ListPlayer.Add(new PlayerVM(p));
            }
        }

        internal void EditSelection(int id, Type type)
        {
            object[] parameters = new object[3];
            Frame frame = (Frame)Window.Current.Content;
            if(type == typeof(PlayerVM))
            {
                parameters[0] = ListPlayer[id];
            }
            else if(type == typeof(ItemsVM))
            {
                parameters[0] = ListItems[id];
            }
            parameters[1] = this;
            parameters[2] = id;
            frame.Navigate(typeof(ViewEdit), parameters );
        }

        public void ListItemsInit()
        {
            foreach(Personnage p in Stub.LesPersoAvecStuffs())
            {
                foreach(Item i in p.ROCInventaire)
                {
                    ListItems.Add(new ItemsVM(i));
                }
            }
        }


        private void ClickDisconnect()
        {
            Frame currentFrame = (Frame)Window.Current.Content;
            while(currentFrame.CanGoBack)
            {
                currentFrame.GoBack();
            }
        }
    }
}
