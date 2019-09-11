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
	public partial class PersonnagePage : ContentPage
	{
		public PersonnagePage(PersoVM personnageVM)
		{
			InitializeComponent ();
            BindingContext = personnageVM;
		}
	}
}