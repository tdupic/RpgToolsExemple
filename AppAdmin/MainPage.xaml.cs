using AppAdmin.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AppAdmin
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
  private const string ID = "coco";
        private const string pass = "fromy";
        public MainPage()
        {
            this.InitializeComponent();
        }

        async private void Connexion_Click(object sender, RoutedEventArgs e)
        {
            if(idBox.Text == ID && passBox.Password == pass)
            {
                this.Frame.Navigate(typeof(ViewAdmin));
            }
            else
            {
                await new MessageDialog("Id or pass is incorrect", "Error").ShowAsync(); 
            }
        }

        private void EnterPress(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key == VirtualKey.Enter)
            {
                Connexion_Click(sender, new RoutedEventArgs());
            }
        }
    }
}
