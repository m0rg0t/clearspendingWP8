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
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.DataForm;
using ClearSpendingSDK.Models;

namespace ClearSpendingSearchWP8.Pages
{

    public class RegionsInfoProvider : IGenericListFieldInfoProvider
    {
        public System.Collections.IEnumerable ItemsSource
        {
            get
            {
                var items = (from x in ViewModelLocator.MainStatic.Regions.RegionItems
                             select x.Name).OrderBy(c => c).ToList();
                items.Insert(0, "Все регионы");
                return items;
            }
        }

        public IGenericListValueConverter ValueConverter
        {
            get { return null; }
        }
    }

    public class SearchParamCustomerItemEx : SearchParamCustomerItem
    {
        [GenericListEditor(typeof(RegionsInfoProvider))]
        public string RegionItems
        {
            get;
            set;
        }
    }

    public partial class CustomersPage : PhoneApplicationPage
    {
        public CustomersPage()
        {
            InitializeComponent();
        }

        public SearchParamCustomerItemEx item = new SearchParamCustomerItemEx();

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.CustomersSearch.Commit();

                try
                {
                    item.Regioncode =
                        ViewModelLocator.MainStatic.Regions.RegionItems.FirstOrDefault(c => c.Name == item.RegionItems).Id;
                }
                catch
                {
                    item.Regioncode = "";
                }

                ViewModelLocator.MainStatic.SearchParams.Customer = (SearchParamCustomerItem)item;
                ViewModelLocator.MainStatic.SearchParams.CurrentType = SearchParamItem.SearchType.Customers;

                ViewModelLocator.MainStatic.Loading = true;

                //start searching
                await ViewModelLocator.MainStatic.SearchItem.StartSearch(ViewModelLocator.MainStatic.SearchParams);
                ResultsCustomers.ItemsSource = ViewModelLocator.MainStatic.SearchItem.CustomerItems;
                CustomersPivot.SelectedIndex = 1;

                ViewModelLocator.MainStatic.Loading = false;
            }
            catch
            {
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.CustomersSearch.CurrentItem = item; //ViewModelLocator.MainStatic.SearchParams.Customer;
        }

        private void ResultsCustomers_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {
            try
            {
                ViewModelLocator.MainStatic.SearchItem.CurrentCustomerItem = (CustomerItem)ResultsCustomers.SelectedItem;
                NavigationService.Navigate(new Uri("/Pages/CustomerDetailPage.xaml", UriKind.Relative));
            }
            catch
            {
            }
        }
    }
}