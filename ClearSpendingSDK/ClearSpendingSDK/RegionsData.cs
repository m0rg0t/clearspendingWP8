using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Newtonsoft.Json.Linq;

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
                        new Uri("https://clearspending.p.mashape.com/v1/regions/select?regioncode=all"));
                string RawResult = await result.Content.ReadAsStringAsync();
                JObject resultJObject = JObject.Parse(RawResult);
                Debug.WriteLine(RawResult);
            }
            catch
            {
            }

            return true;
        }
    }
}
