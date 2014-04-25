using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using ClearSpendingSDK.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics;
using Newtonsoft.Json.Serialization;

namespace ClearSpendingSDK
{    

    public class ContractSearch: ViewModelBase
    {
        public async Task<bool> StartSearch(SearchParamItem paramsItem)
        {
            switch (paramsItem.CurrentType)
            {
                case SearchParamItem.SearchType.Contracts:
                    await SearchContractsData(paramsItem);
                    break;
                case SearchParamItem.SearchType.Customers:
                    await SearchCustomersData(paramsItem);
                    break;
                case SearchParamItem.SearchType.Suppliers:
                    await SearchSuppliersData(paramsItem);
                    break;
                default:
                    await SearchContractsData(paramsItem);
                    break;
            }
            return true;
        }

        public async Task<bool> SearchSuppliersData(SearchParamItem paramsItem)
        {
            HttpClient http = new HttpClient();
            http.DefaultRequestHeaders.Add("X-Mashape-Authorization", Settings.AuthKey);
            string values = paramsItem.ToString();
            HttpResponseMessage result = await
                http.GetAsync(
                    new Uri("https://clearspending.p.mashape.com/v1/suppliers/search/" + values));
            RawResult = await result.Content.ReadAsStringAsync();
            JObject resultJObject = new JObject();
            try
            {
                resultJObject = JObject.Parse(RawResult);
            }
            catch
            {
            }

            try
            {
                SupplierItems = new ObservableCollection<SupplierItem>();
                SupplierItems = JsonConvert.DeserializeObject<ObservableCollection<SupplierItem>>(resultJObject["suppliers"]["data"].ToString());
            }
            catch { }

            return true;
        }

        public async Task<bool> SearchCustomersData(SearchParamItem paramsItem)
        {
            HttpClient http = new HttpClient();
            http.DefaultRequestHeaders.Add("X-Mashape-Authorization", Settings.AuthKey);
            string values = paramsItem.ToString();
            HttpResponseMessage result = await
                http.GetAsync(
                    new Uri("https://clearspending.p.mashape.com/v1/customers/search/" + values));
            RawResult = await result.Content.ReadAsStringAsync();
            JObject resultJObject = new JObject();
            try
            {
                resultJObject = JObject.Parse(RawResult);
            }
            catch
            {
            }

            try
            {
                Total = resultJObject["customers"]["total"].Value<int>();
            }
            catch
            {
                Total = 0;
            }

            try
            {
                CustomerItems = new ObservableCollection<CustomerItem>();
                CustomerItems = JsonConvert.DeserializeObject<ObservableCollection<CustomerItem>>(resultJObject["customers"]["data"].ToString());
            }
            catch { }

            return true;
        }

        public async Task<bool> SearchContractsData(SearchParamItem paramsItem)
        {
            HttpClient http = new HttpClient();
            http.DefaultRequestHeaders.Add("X-Mashape-Authorization", Settings.AuthKey);
            string values = paramsItem.ToString();
            HttpResponseMessage result = await
            http.GetAsync(
                new Uri("https://clearspending.p.mashape.com/v1/contracts/search/" + values));
            RawResult = await result.Content.ReadAsStringAsync();
            JObject resultJObject = new JObject();
            try
            {
                resultJObject = JObject.Parse(RawResult);
            }
            catch
            {
                resultJObject = null;
            }

            ContractItems = new List<ContractItem>();

            try
            {
                if (resultJObject!=null)
                Total = resultJObject["contracts"]["total"].Value<int>();
            }
            catch
            {
                Total = 0;
            }

            try
            {
                if (resultJObject != null)
                {
                    JArray dataItems = JArray.Parse(resultJObject["contracts"]["data"].ToString());
                    foreach (var item in dataItems)
                    {
                        var curContract = new ContractItem();
                        curContract.Customer = JsonConvert.DeserializeObject<CustomerItem>(item["customer"].ToString());
                        try
                        {
                            curContract.Products =
                                JsonConvert.DeserializeObject<ProductsItems>(item["products"].ToString());
                        }
                        catch
                        {
                            try
                            {
                                ProductItem product =
                                    JsonConvert.DeserializeObject<ProductItem>(item["products"]["product"].ToString());
                                curContract.Products.Product.Add(product);
                            }
                            catch
                            {
                            }
                            ;
                        }
                        ;

                        curContract.Price = item["price"].ToString();
                        curContract.Id = item["id"].ToString();
                        curContract.RegNum = item["regNum"].ToString();
                        curContract.SearchRank = item["searchRank"].ToString();
                        try
                        {
                            curContract.SignDate = item["signDate"].Value<DateTime>();
                        }
                        catch
                        {
                        }
                        ;
                        curContract.Suppliers =
                            JsonConvert.DeserializeObject<SuppliersItems>(item["suppliers"].ToString());

                        ContractItems.Add(curContract);
                    }
                    //ContractItems = JsonConvert.DeserializeObject<List<ContractItem>>(resultJObject["contracts"]["data"].ToString());
                    RaisePropertyChanged("ContractItems");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            RaisePropertyChanged("ContractItems");
            return true;
        }

        private List<ContractItem> _contractItems = new List<ContractItem>();
        /// <summary>
        /// 
        /// </summary>
        public List<ContractItem> ContractItems
        {
            get { 
                return _contractItems; 
            }
            set { 
                _contractItems = value;
                RaisePropertyChanged("ContractItems");
            }
        }

        private ObservableCollection<SupplierItem> _supplierItems;
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<SupplierItem> SupplierItems
        {
            get { return _supplierItems; }
            set
            {
                _supplierItems = value;
                RaisePropertyChanged("SupplierItems");
            }
        }
        

        private ObservableCollection<CustomerItem> _customerItems;
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<CustomerItem> CustomerItems
        {
            get { return _customerItems; }
            set
            {
                _customerItems = value;
                RaisePropertyChanged("CustomerItems");
            }
        }

        /*private ObservableCollection<SupplierItem> _supplierItems;
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<SupplierItem> SupplierItems
        {
            get { return _supplierItems; }
            set { _supplierItems = value; }
        }*/
        
        

        private ContractItem _currentContractItem = null;
        /// <summary>
        /// 
        /// </summary>
        public ContractItem CurrentContractItem
        {
            get { return _currentContractItem; }
            set { 
                _currentContractItem = value;
                RaisePropertyChanged("CurrentContractItem");
            }
        }

        private SupplierItem _currentSupplierItem;

        public SupplierItem CurrentSupplierItem
        {
            get { return _currentSupplierItem; }
            set
            {
                _currentSupplierItem = value;
                RaisePropertyChanged("CurrentSupplierItem");
            }
        }

        private CustomerItem _currentCustomerItem;
        /// <summary>
        /// 
        /// </summary>
        public CustomerItem CurrentCustomerItem
        {
            get { return _currentCustomerItem; }
            set
            {
                _currentCustomerItem = value;
                RaisePropertyChanged("CurrentCustomerItem");
            }
        }
        

        private string _rawResult;
        /// <summary>
        /// Сырое ответ от сервера
        /// </summary>
        public string RawResult
        {
            get { return _rawResult; }
            set { _rawResult = value; }
        }

        private int _total;
        /// <summary>
        /// Общее количество контрактов по результатам поиска
        /// </summary>
        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }
        
        
    }
}
