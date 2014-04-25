using System.Diagnostics;
using GalaSoft.MvvmLight;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClearSpendingSDK.Models
{
    public class CustomerItem: ViewModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string Kpp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private string _regNum;
        /// <summary>
        /// 
        /// </summary>
        public string RegNum
        {
            get { return _regNum; }
            set
            {
                _regNum = value;
                if (!String.IsNullOrEmpty(_regNum))
                {
                    this.RegNumber = _regNum;
                }
                RaisePropertyChanged("RegNum");
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Inn { get; set; }

        private double _contractsCount;
        /// <summary>
        /// 
        /// </summary>
        public double ContractsCount
        {
            get { return _contractsCount; }
            set
            {
                _contractsCount = value;
                RaisePropertyChanged("ContractsCount");
            }
        }

        private double _contractsSum;
        /// <summary>
        /// 
        /// </summary>
        public double ContractsSum
        {
            get { return _contractsSum; }
            set
            {
                _contractsSum = value;
                RaisePropertyChanged("ContractsSum");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string RegNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SearchRank { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        public async Task<bool> LoadFullCustomerData()
        {
            HttpClient http = new HttpClient();
            http.DefaultRequestHeaders.Add("X-Mashape-Authorization", Settings.AuthKey);
            HttpResponseMessage result = await
                http.GetAsync(
                    new Uri("https://clearspending.p.mashape.com//v1/customers/get/?spzregnum=" + this.RegNumber));
            string RawResult = await result.Content.ReadAsStringAsync();
            try
            {
                JObject resultJObject = new JObject();
                resultJObject = JObject.Parse(RawResult);
                string json = resultJObject["customers"]["data"].ToString();
                var items = JsonConvert.DeserializeObject<List<CustomerDetailedItem>>(json);
                Details = items.FirstOrDefault();

                try
                {
                    this.ContractsSum = resultJObject["customers"]["data"][0]["contractsSum"].Value<double>();
                    this.ContractsCount = resultJObject["customers"]["data"][0]["contractsCount"].Value<double>();
                }
                catch
                {
                }
            }
            catch
            {
            }

            Debug.WriteLine(RawResult);
            return true;
        }

        private CustomerDetailedItem _detals;
        /// <summary>
        /// 
        /// </summary>
        public CustomerDetailedItem Details
        {
            get { return _detals; }
            set
            {
                _detals = value;
                RaisePropertyChanged("Details");
            }
        }
    }

    public class CustomerDetailedItem : ViewModelBase
    {
        public string RegionCode { get; set; }
        public string Email { get; set; }

        private string _fax;
        /// <summary>
        /// 
        /// </summary>
        public string Fax
        {
            get { return _fax; }
            set
            {
                _fax = value;
                RaisePropertyChanged("Fax");
            }
        }

        private string _phone;
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                RaisePropertyChanged("Phone");
            }
        }

        public FactualAddressItem FactualAddress { get; set; }

        public string PostalAddress { get; set; }
    }

    public class FactualAddressItem
    {
        public string AddressLine { get; set; }
        public string Zip { get; set; }
        public string Building { get; set; }
        public string OKATO { get; set; }
        public string ShortStreet { get; set; }
    }
}
