using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Telerik.Windows.Controls;
using ClearSpendingSearchWP8.ViewModel;
using Telerik.Windows.Controls.DataForm;
using ClearSpendingSDK.Models;

namespace ClearSpendingSearchWP8.Pages
{

    public class SuppliersRegionsInfoProvider : IGenericListFieldInfoProvider
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

    public class SearchParamSupplierItemEx : SearchParamSupplierItem
    {
        [GenericListEditor(typeof(SuppliersRegionsInfoProvider))]
        public string RegionItems
        {
            get;
            set;
        }
    }

    public partial class SuppliersPage : PhoneApplicationPage
    {
        public SearchParamSupplierItemEx item = new SearchParamSupplierItemEx();

        public SuppliersPage()
        {
            InitializeComponent();
        }

        private async void SearchButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.SuppliersSearch.Commit();

                try
                {
                    item.Regioncode =
                        ViewModelLocator.MainStatic.Regions.RegionItems.FirstOrDefault(c => c.Name == item.RegionItems).Id;
                }
                catch
                {
                    item.Regioncode = "";
                }

                ViewModelLocator.MainStatic.SearchParams.Supplier = (SearchParamSupplierItem)item;
                ViewModelLocator.MainStatic.SearchParams.CurrentType = SearchParamItem.SearchType.Suppliers;

                ViewModelLocator.MainStatic.Loading = true;

                //start searching
                await ViewModelLocator.MainStatic.SearchItem.StartSearch(ViewModelLocator.MainStatic.SearchParams);
                ResultsSuppliers.ItemsSource = ViewModelLocator.MainStatic.SearchItem.SupplierItems;
                this.SuppliersPivot.SelectedIndex = 1;

                ViewModelLocator.MainStatic.Loading = false;
            }
            catch
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ResultsCustomers_OnItemTap(object sender, ListBoxItemTapEventArgs e)
        {
            //throw new NotImplementedException();
            try
            {

            }
            catch
            {
            }
        }

        private void SuppliersPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            /*try
            {
                this.SuppliersSearch.CurrentItem = item; 
            }
            catch
            {
            }*/
        }

        private void SuppliersSearch_OnLoaded(object sender, RoutedEventArgs e)
        {
            item = new SearchParamSupplierItemEx();
            item.Inn = "";
            //item.Inblacklist = false;
            item.Kpp = "";
            item.Namesearch = "";
            item.Orgform = "";
            item.Regioncode = "";
            this.SuppliersSearch.CurrentItem = item; 
        }
    }
}