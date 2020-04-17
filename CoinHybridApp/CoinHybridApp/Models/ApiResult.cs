using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinHybridApp.Models
{
   public class ApiResult
    {

        [JsonProperty("data")]
        public IEnumerable<CryptocurencyModel> Cryptos { get; set; }
        public IEnumerable<CryptocurencyModel> CryptosChart { get; set; }




    }
   
}
