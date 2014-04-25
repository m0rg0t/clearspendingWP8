using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ClearSpendingSearchWP8.ViewModel;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ClearSpendingSearchWP8.Pages
{
    public partial class CustomerDetailPage : PhoneApplicationPage
    {
        public CustomerDetailPage()
        {
            InitializeComponent();
        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MainStatic.Loading = true;
            await ViewModelLocator.MainStatic.SearchItem.CurrentCustomerItem.LoadFullCustomerData();
            ViewModelLocator.MainStatic.Loading = false;
        }
    }
}