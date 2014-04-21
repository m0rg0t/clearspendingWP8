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
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.DataForm;
using System.Reflection;

namespace ClearSpendingSearchWP8.Pages
{
    public class CountriesInfoProvider : IGenericListFieldInfoProvider
    {
        public System.Collections.IEnumerable ItemsSource
        {
            get
            {
                var items = (from x in ViewModelLocator.MainStatic.Regions.RegionItems
                    select x.Name).OrderBy(c=>c).ToList();
                items.Insert(0, "Все регионы");
                return items;
            }
        }

        public IGenericListValueConverter ValueConverter
        {
            get { return null; }
        }
    }

    public class SearchParamContractItemEx: SearchParamContractItem
    {
        [GenericListEditor(typeof(CountriesInfoProvider))]
        public string RegionItems
        {
            get;
            set;
        }

        /*private string _regionItems;
        /// <summary>
        /// 
        /// </summary>
        [GenericListEditor(typeof(CountriesInfoProvider))]
        public string RegionItems
        {
            get { return _regionItems; }
            set
            {
                _regionItems = value;
                try
                {
                    this.Customerregion =
                        ViewModelLocator.MainStatic.Regions.RegionItems.FirstOrDefault(c => c.Name == value).Id;
                }
                catch
                {
                }
            }
        }*/

        /*public ExtendedObject(SearchParamContractItem parent)
        {
            foreach (PropertyInfo prop in parent.GetType().GetProperties())
                GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(parent, null), null);
        }*/
    }

    public partial class ContractsPage : PhoneApplicationPage
    {
        public ContractsPage()
        {
            InitializeComponent();
        }

        public SearchParamContractItemEx item = new SearchParamContractItemEx();

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            /*ViewModelLocator.MainStatic.SearchParams.Contract.RegionItems = new List<string>();
            ViewModelLocator.MainStatic.SearchParams.Contract.RegionItems =  
                (from x in ViewModelLocator.MainStatic.Regions.RegionItems
                select x.Name).ToList();
            ViewModelLocator.MainStatic.SearchParams.Contract.RegionItems.Add("Все регионы");*/
            
            this.ContractsSearch.CurrentItem = item;
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            this.ContractsSearch.Commit();
            try
            {
                item.Customerregion =
                    ViewModelLocator.MainStatic.Regions.RegionItems.FirstOrDefault(c => c.Name == item.RegionItems).Id;
            }
            catch
            {
                item.Customerregion = "";
            }

            ViewModelLocator.MainStatic.SearchParams.Contract = (SearchParamContractItem)item;

            ViewModelLocator.MainStatic.Loading = true;
            //start searching
            await ViewModelLocator.MainStatic.ContractSearchItem.StartSearch(ViewModelLocator.MainStatic.SearchParams);
            ViewModelLocator.MainStatic.Loading = false;

            ResultsContracts.ItemsSource = ViewModelLocator.MainStatic.ContractSearchItem.ContractItems;
            ContractPivot.SelectedIndex = 1; // = ContractPivot.Items[0];
        }

        private void ResultsContracts_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {
            try
            {
                ViewModelLocator.MainStatic.ContractSearchItem.CurrentContractItem = (ContractItem)ResultsContracts.SelectedItem;
                NavigationService.Navigate(new Uri("/Pages/ContractDetailPage.xaml", UriKind.Relative));
            }
            catch { };
        }
    }
}