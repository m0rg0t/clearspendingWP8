using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ClearSpendingSearchWP8.ViewModel;

namespace ClearSpendingSearchWP8.Pages
{
    public partial class CustomersPage : PhoneApplicationPage
    {
        public CustomersPage()
        {
            InitializeComponent();
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.CustomersSearch.Commit();
                //start searching
                await ViewModelLocator.MainStatic.ContractSearchItem.StartSearch(ViewModelLocator.MainStatic.SearchParams);
                ResultsCustomers.ItemsSource = ViewModelLocator.MainStatic.ContractSearchItem.ContractItems;
            }
            catch
            {
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.CustomersSearch.CurrentItem = ViewModelLocator.MainStatic.SearchParams.Customer;
        }

        private void ResultsContracts_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {
            try
            {

            }
            catch
            {
            }
        }
    }
}