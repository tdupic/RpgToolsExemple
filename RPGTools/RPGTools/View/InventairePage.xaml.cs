using DLToolkit.Forms.Controls;
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
	public partial class InventairePage : ContentPage
	{
		public InventairePage(PersoVM personnageVM)
		{
			InitializeComponent ();
            FlowListView.Init();
            BindingContext = personnageVM;            
		}
	}
}