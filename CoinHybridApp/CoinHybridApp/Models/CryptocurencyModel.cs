using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinHybridApp.Models
{
    using Newtonsoft.Json;
    using SQLite;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CryptocurencyModel
    {
        
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        
       

        [JsonProperty("supply")]
        public string Supply { get; set; }

        [JsonProperty("maxSupply")]
        public string MaxSupply { get; set; }

        [JsonProperty("marketCapUsd")]
        public string MarketCapUsd { get; set; }

        [JsonProperty("volumeUsd24Hr")]
        public string VolumeUsd24Hr { get; set; }

        [JsonProperty("changePercent24Hr")]
        public string ChangePercent24Hr { get; set; }
        [Column("PriceUsd")]
        [JsonProperty("priceUsd")]
        public string PriceUsd { get; set; }

        [JsonProperty("vwap24Hr")]
        public string Vwap24Hr { get; set; }
        public string ImageUrl { get; set; }

        //--------------For charts-------------------
        [JsonProperty("time")]
        public object Time { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("data")]
        [Ignore]
        public IEnumerable<CryptocurencyModel> Cryptos { get; set; }
        public CryptocurencyModel()
        {

        }
      
    }
}
