using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using ClearSpendingSDK.Models;
using ClearSpendingSDK;
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
            this.ContractSearchItem = new ContractSearch();

            Regions = new RegionsData();
            BudgetLevels = new BudgetLevels();

            LoadData();
        }

        public async Task<bool> LoadData()
        {
            Loading = true;

            await Regions.LoadData();
            await BudgetLevels.LoadData();

            Loading = false;

            return true;
        }

        private BudgetLevels _budgetLevels;
        /// <summary>
        /// 
        /// </summary>
        public BudgetLevels BudgetLevels
        {
            get { return _budgetLevels; }
            set { _budgetLevels = value; }
        }

        private SearchParamItem _searchParams = new SearchParamItem();
        /// <summary>
        /// Параметры поиска для контрактов
        /// </summary>
        public SearchParamItem SearchParams
        {
            get { return _searchParams; }
            set { 
                _searchParams = value;
                RaisePropertyChanged("SearchParams");
            }
        }

        public ContractSearch ContractSearchItem { get; set; }

        private bool _loading = false;
        /// <summary>
        /// Loading progress
        /// </summary>
        public bool Loading
        {
            get { return _loading; }
            set
            {
                _loading = value;
                RaisePropertyChanged("Loading");
            }
        }

        private RegionsData _regions;
        /// <summary>
        /// Регоины
        /// </summary>
        public RegionsData Regions
        {
            get { return _regions; }
            set { _regions = value; }
        }
        
        
    }
}