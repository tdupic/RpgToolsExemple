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
    public partial class AddSortPage : ContentPage
    {
        PersoVM vm;
        public AddSortPage(PersoVM inVM)
        {
            vm = inVM;
            InitializeComponent();
            entryName.Text = " ";
            entryEffet.Text = " ";
            entryCout.Text = " ";
            entryMtt.Text = " ";
            entryCooldown.Text = " ";
        }

        async private void AddClicked(object sender, EventArgs e)
        {
            if(entryName.Text != " " && entryEffet.Text != " " && entryCout.Text != " " && entryMtt.Text != " " && entryCooldown.Text != " ")
            {
                string nom = entryName.Text;
                string effet = entryEffet.Text;
                int cout = int.Parse(entryCout.Text);
                int mtt = int.Parse(entryCout.Text);
                int cooldown = int.Parse(entryCooldown.Text);
                vm.Spells.Add(new SortsVM(new BiblioJdr.Sort(nom, effet, mtt, cout)));
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error !", "A field is empty...", "OK");
            }
        }
    }
}