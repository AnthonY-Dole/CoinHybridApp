using CoinHybridApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinHybridApp.Service
{
   public static class HttpService
    {
        //String for call api
        const string BASE_URL = "https://api.coincap.io/v2/";
        const string ASSETS_ENDPOINT = "assets";
        const string ASSETS_ENDPOINT_Limit = "assets/?limit=10";
        const string HISTORYS_ENDPOINT = "/history?interval=";


        //Get all cryptocurrency data (name,price etc..)
        public static async Task<IEnumerable<CryptocurencyModel>> GetAssetsAsync()
        {
            using (var httpClient = new HttpClient())
            {
                
                var jsonString = await httpClient.GetStringAsync(BASE_URL + ASSETS_ENDPOINT);
                var posts = JsonConvert.DeserializeObject<CryptocurencyModel>(jsonString).Cryptos;
                return posts;
            }
        }
        //Get cryptocurency with limit for buy sell
        public static async Task<IEnumerable<CryptocurencyModel>> GetAssetsLimitAsync()
        {
            using (var httpClient = new HttpClient())
            {

                var jsonString = await httpClient.GetStringAsync(BASE_URL + ASSETS_ENDPOINT_Limit);
                var postsLimit = JsonConvert.DeserializeObject<CryptocurencyModel>(jsonString).Cryptos;
                return postsLimit;
            }
        }
        //Get history data for one cryptocurrency in parameter
        public static async Task<IEnumerable<CryptocurencyModel>> GetValuesChartAsync(string asset,string time)
        {
            using (var httpClient = new HttpClient())
            {

                var jsonString = await httpClient.GetStringAsync(BASE_URL + ASSETS_ENDPOINT + "/"+asset + HISTORYS_ENDPOINT+time);
                var chart = JsonConvert.DeserializeObject<CryptocurencyModel>(jsonString).Cryptos;
                return chart;

            }
        }
    }
}
