using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Newtonsoft.Json.Linq;
using ClearSpendingSDK.Models;
using Newtonsoft.Json;

namespace ClearSpendingSDK
{
    public class RegionsData: ViewModelBase
    {
        public RegionsData()
        {
            
        }

        public async Task<bool> LoadData()
        {
            try
            {
                HttpClient http = new HttpClient();
                http.DefaultRequestHeaders.Add("X-Mashape-Authorization", Settings.AuthKey);
                //http.DefaultRequestHeaders.Add("X-Mashape-Authorization", "IcScDgM8G8TgCWJfj7SzIFf2NfkAoJMH");

                HttpResponseMessage result = await
                    http.GetAsync(
                        new Uri("https://clearspending.p.mashape.com/v1/regions/select/?regioncode=all"));
                string RawResult = await result.Content.ReadAsStringAsync();
                JObject resultJObject = JObject.Parse(RawResult);
                RegionItems = JsonConvert.DeserializeObject<ObservableCollection<RegionItem>>(resultJObject["regions"]["data"].ToString());
                Debug.WriteLine(RawResult);
            }
            catch
            {
            }
            return true;
        }

        private ObservableCollection<RegionItem> _regionItems = new ObservableCollection<RegionItem>();
        /// <summary>
        /// Список регионов
        /// </summary>
        public ObservableCollection<RegionItem> RegionItems
        {
            get { return _regionItems; }
            set
            {
                _regionItems = value;
                RaisePropertyChanged("RegionItems");
            }
        }
        
    }
}
