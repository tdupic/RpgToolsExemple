using AppAdmin.Services;
using AppAdmin.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AppAdmin.ViewModel
{
    public class EditVM : BaseViewModel
    {
        public ICommand CmdValide { get; set; }

        internal object[] parameters;

        private PlayerVM _selectedPlayer;
        public PlayerVM SelectedPlayer
        {
            get => _selectedPlayer;
            set => SetValue(ref _selectedPlayer, value);
        }
        private ItemsVM _selectedItem;
        public ItemsVM SelectedItem
        {
            get => _selectedItem;
            set => SetValue(ref _selectedItem, value);
        }

        private string _nom;
        public string Nom
        {
            get => _nom;
            set => SetValue(ref _nom, value);
        }

        private ViewModelAdmin coreVM;

        public EditVM()
        {
            CmdValide = new RelayCommand(ClickValider);
        }

        public void Init()
        {
            object oui = parameters[0];
            if (oui is PlayerVM)
            {
                SelectedPlayer = (PlayerVM)parameters[0];
                Nom = SelectedPlayer.Nom;
            }
            else
            {
                SelectedItem = (ItemsVM)parameters[0];
                Nom = SelectedItem.Nom;
            }
            coreVM = (ViewModelAdmin)parameters[1];
        }

        private void ClickValider()
        {
            int id = (int)parameters[2];
            if (parameters[0] is PlayerVM)
            {
                SelectedPlayer.Nom = Nom;
                this.coreVM.ListPlayer[id] = SelectedPlayer;
            }
            else
            {
                SelectedItem.Nom = Nom;
                this.coreVM.ListItems[id] = SelectedItem;
            }
            Frame frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(ViewAdmin), coreVM);
        }
    }
}
