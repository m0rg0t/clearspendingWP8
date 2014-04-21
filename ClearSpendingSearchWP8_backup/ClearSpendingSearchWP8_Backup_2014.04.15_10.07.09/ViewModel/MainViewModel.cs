using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using GalaSoft.MvvmLight;
using ClearSpendingSDK.Models;
using System.Net.Http;

namespace ClearSpendingSearchWP8.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            /// 
            /*HttpResponse<MyClass> response = Unirest.get("https://clearspending.p.mashape.com/v1/contracts/select/?regnum=0361300001711000053&customerinn=6504020670&customerkpp=650401001&supplierinn=6504016811&supplierkpp=650401001&okdp=1520110&budgetlevel=02&customerregion=65&daterange=27.01.2011-01.02.2011&pricerange=300000-400000&placing=5&page=1&perpage=50&returnfields=%5Bprice%2CregNum%2Cproducts%5D&sort=price")
              .header("X-Mashape-Authorization", "IcScDgM8G8TgCWJfj7SzIFf2NfkAoJMH")
              .asJson<MyClass>();*/
            
        }

        //test function
        public async void TestLoad()
        {
            return;
            HttpClient http = new HttpClient();
            http.DefaultRequestHeaders.Add("X-Mashape-Authorization", "IcScDgM8G8TgCWJfj7SzIFf2NfkAoJMH");
            HttpResponseMessage result = await
                http.GetAsync(
                    new Uri("https://clearspending.p.mashape.com/v1/contracts/search/?page=1&perpage=10&Productsearch=молоко"));
            string outStr = await result.Content.ReadAsStringAsync();
            Debug.WriteLine(outStr);

        }

        private ObservableCollection<ContractItem> _searchContractsItems = new ObservableCollection<ContractItem>();
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<ContractItem> SearchContractItems
        {
            get
            {
                return _searchContractsItems;
            }
            set
            {
                _searchContractsItems = value;
            }
        }
        
    }
}