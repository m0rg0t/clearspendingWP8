using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ClearSpendingSDK.Models;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ClearSpendingSearchWP8.ViewModel;

namespace ClearSpendingSearchWP8.Pages
{
    public partial class ContractDetailPage : PhoneApplicationPage
    {
        public ContractDetailPage()
        {
            InitializeComponent();
        }

        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            try
            {
                ViewModelLocator.MainStatic.SearchItem.CurrentCustomerItem =
                    (CustomerItem)ViewModelLocator.MainStatic.SearchItem.CurrentContractItem.Customer;
                NavigationService.Navigate(new Uri("/Pages/CustomerDetailPage.xaml", UriKind.Relative));
            }
            catch
            {
            }
        }
    }
}