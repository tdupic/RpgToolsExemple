using AppAdmin.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace AppAdmin.View
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class ViewAddItem : Page
    {
        public ViewModelAdmin VMAdmin
        {
            get => DataContext as ViewModelAdmin;
            set => DataContext = value;
        }

        public ViewAddItem()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            VMAdmin = (ViewModelAdmin)e.Parameter;
        }

        private void RdBttArmeChecked(object sender, RoutedEventArgs e)
        {
            txtBlockEffet.Visibility = Visibility.Visible;
            txtBlockMtt.Visibility = Visibility.Visible;
            txtBoxEffet.Visibility = Visibility.Visible;
            txtBoxMtt.Visibility = Visibility.Visible;
        }

        private void RdBttArmureChecked(object sender, RoutedEventArgs e)
        {
            txtBlockEffet.Visibility = Visibility.Visible;
            txtBlockMtt.Visibility = Visibility.Visible;
            txtBoxEffet.Visibility = Visibility.Visible;
            txtBoxMtt.Visibility = Visibility.Visible;
        }

        private void RdBttPotionChecked(object sender, RoutedEventArgs e)
        {
            txtBlockEffet.Visibility = Visibility.Visible;
            txtBlockMtt.Visibility = Visibility.Collapsed;
            txtBoxEffet.Visibility = Visibility.Visible;
            txtBoxMtt.Visibility = Visibility.Collapsed;
        }

        private void RdBttNouritureChecked(object sender, RoutedEventArgs e)
        {
            txtBlockEffet.Visibility = Visibility.Collapsed;
            txtBlockMtt.Visibility = Visibility.Collapsed;
            txtBoxEffet.Visibility = Visibility.Collapsed;
            txtBoxMtt.Visibility = Visibility.Collapsed;
        }
    }
}
