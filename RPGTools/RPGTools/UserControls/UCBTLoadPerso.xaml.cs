using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RPGTools.UserControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UCBTLoadPerso : ContentView
	{
        public static readonly BindableProperty NameProperty = 
            BindableProperty.Create(nameof(Name), typeof(String), typeof(String), default(string), Xamarin.Forms.BindingMode.TwoWay);
        public string Name
        {
            get
            {
                return (string)GetValue(NameProperty);
            }

            set
            {
                SetValue(NameProperty, value);
            }
        }

        public static readonly BindableProperty LevelProperty =
            BindableProperty.Create(nameof(Level), typeof(string), typeof(string), default(string), Xamarin.Forms.BindingMode.TwoWay);
        public string Level
        {
            get
            {
                return (string)GetValue(LevelProperty);
            }

            set
            {
                SetValue(LevelProperty, value);
            }
        }


        public UCBTLoadPerso()
		{
			InitializeComponent();
		}
    }
}