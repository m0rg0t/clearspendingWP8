﻿using System;
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
                    await SearchContractsData(paramsItem);
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
            }

            ContractItems = new List<ContractItem>();

            try
            {
                Total = resultJObject["contracts"]["total"].Value<int>();
            }
            catch
            {
                Total = 0;
            }

            try
            {
                JArray dataItems = JArray.Parse(resultJObject["contracts"]["data"].ToString());
                foreach (var item in dataItems)
                {
                    var curContract = new ContractItem();
                    curContract.Customer = JsonConvert.DeserializeObject<CustomerItem>(item["customer"].ToString());
                    try
                    {
                        curContract.Products = JsonConvert.DeserializeObject<ProductsItems>(item["products"].ToString());
                    }
                    catch
                    {
                        try
                        {
                            ProductItem product = JsonConvert.DeserializeObject<ProductItem>(item["products"]["product"].ToString());
                            curContract.Products.Product.Add(product);
                        }
                        catch { };
                    };

                    curContract.Price = item["price"].ToString();
                    curContract.Id = item["id"].ToString();
                    curContract.RegNum = item["regNum"].ToString();
                    curContract.SearchRank = item["searchRank"].ToString();
                    try
                    {
                        curContract.SignDate = item["signDate"].Value<DateTime>();
                    }
                    catch { };
                    curContract.Suppliers = JsonConvert.DeserializeObject<SuppliersItems>(item["suppliers"].ToString());

                    ContractItems.Add(curContract);
                }
                //ContractItems = JsonConvert.DeserializeObject<List<ContractItem>>(resultJObject["contracts"]["data"].ToString());
                RaisePropertyChanged("ContractItems");
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

        private ObservableCollection<ContractItem> _customerItems;
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<ContractItem> CustomerItems
        {
            get { return _customerItems; }
            set
            {
                _customerItems = value;
                RaisePropertyChanged("CustomerItems");
            }
        }
        

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