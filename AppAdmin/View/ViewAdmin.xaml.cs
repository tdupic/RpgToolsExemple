using AppAdmin.ViewModel;
using System;
﻿using System;
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
    public sealed partial class ViewAdmin : Page
    {
        public ViewModelAdmin VMAdmin
        {
            get => DataContext as ViewModelAdmin;
            set => DataContext = value;
        }

        public ViewAdmin()
        {
            
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if(e.Parameter != null)
            {
                VMAdmin = (ViewModelAdmin)e.Parameter;
            }
            else
            {
                VMAdmin = new ViewModelAdmin();
            }
           
        }

        private void BttPlayerClick(object sender, RoutedEventArgs e)
        {
            ListViewVAdmin.ItemsSource = VMAdmin.ListPlayer;
            ContentBar.Content = "Players";
        }

        private void BttItemsClick(object sender, RoutedEventArgs e)
        {
            ListViewVAdmin.ItemsSource = VMAdmin.ListItems;
            ContentBar.Content = "Items";
        }

        private void BttEditClick(object sender, RoutedEventArgs e)
        {
            int id = ListViewVAdmin.SelectedIndex;
            Type type = ListViewVAdmin.SelectedItem.GetType();
            VMAdmin.EditSelection(id, type);
        }

        private void BttDeleteClick(object sender, RoutedEventArgs e)
        {
            int id = ListViewVAdmin.SelectedIndex;
            Type type = ListViewVAdmin.SelectedItem.GetType();
            VMAdmin.DeleteSelection(id, type);
        }
    }
}
