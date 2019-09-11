using BiblioJdr;
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
	public partial class AddItemPage : ContentPage
	{
        PersoVM vm;

		public AddItemPage (PersoVM vmToAddItem)
		{
			InitializeComponent ();
            vm = vmToAddItem;
            pickerType.Items.Add("Armure");
            pickerType.Items.Add("Arme");
            pickerType.Items.Add("Potion");
            pickerType.Items.Add("Nourriture");
            pickerType.Items.Add("Divers");
            entryMtt.Text = " ";
            entryEffet.Text = " ";
            entryName.Text = " ";
        }

        async private void AddClicked(object sender, EventArgs e)
        {
            if(entryName.Text != " " && pickerType.SelectedItem != null)
            {
                string itemName = entryName.Text;
                if((pickerType.SelectedItem == "Armure" || pickerType.SelectedItem == "Arme" || pickerType.SelectedItem == "Potion") && (entryEffet.Text!=" " && entryMtt.Text!=" "))
                {
                    string effet = entryEffet.Text;

                    if(pickerType.SelectedItem == "Armure" || pickerType.SelectedItem == "Arme")
                    {
                        int mtt = int.Parse(entryMtt.Text);

                        if (pickerType.SelectedItem == "Armure")
                        {
                            vm.Inventaire.Add(new ItemVM(new Armure(itemName, mtt, effet, 1)));
                            Navigation.PopAsync();
                        }
                        else
                        {
                            vm.Inventaire.Add(new ItemVM(new Arme(itemName, mtt, effet, 1)));
                            Navigation.PopAsync();
                        }
                    }
                    else
                    {
                        vm.Inventaire.Add(new ItemVM(new Potion(itemName, effet, 1)));
                        Navigation.PopAsync();
                    }
                }
                else if(pickerType.SelectedItem == "Nourriture")
                {
                    vm.Inventaire.Add(new ItemVM(new Nouriture(itemName, 1)));
                    Navigation.PopAsync();
                }
                else if(pickerType.SelectedItem == "Divers")
                {
                    vm.Inventaire.Add(new ItemVM(new Divers(itemName, 1)));
                    Navigation.PopAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error !", "A field is empty...", "OK");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error !", "A field is empty...", "OK");
            }
            
        }

        private void PickerTypeIndexChanged(object sender, EventArgs e)
        {
            lblEffet.IsVisible = (pickerType.SelectedItem == "Arme" || pickerType.SelectedItem == "Armure" || pickerType.SelectedItem == "Potion");
            entryEffet.IsVisible = (pickerType.SelectedItem == "Arme" || pickerType.SelectedItem == "Armure" || pickerType.SelectedItem == "Potion");

            lblMtt.IsVisible = (pickerType.SelectedItem == "Arme" || pickerType.SelectedItem == "Armure");
            entryMtt.IsVisible = (pickerType.SelectedItem == "Arme" || pickerType.SelectedItem == "Armure");
        }
    }
}