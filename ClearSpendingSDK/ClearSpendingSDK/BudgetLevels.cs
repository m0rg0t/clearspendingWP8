using ClearSpendingSDK.Models;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClearSpendingSDK
{
    public class BudgetLevels: ViewModelBase
    {

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
                BudgetLevelItems = JsonConvert.DeserializeObject<ObservableCollection<BudgetLevelItem>>(resultJObject["regions"]["data"].ToString());
                Debug.WriteLine(RawResult);
            }
            catch
            {
            }
            return true;
        }

        private ObservableCollection<BudgetLevelItem> _budgetLevelItems = new ObservableCollection<BudgetLevelItem>();
        /// <summary>
        /// Список регионов
        /// </summary>
        public ObservableCollection<BudgetLevelItem> BudgetLevelItems
        {
            get { return _budgetLevelItems; }
            set
            {
                _budgetLevelItems = value;
                RaisePropertyChanged("RegionItems");
            }
        }

    }
}
