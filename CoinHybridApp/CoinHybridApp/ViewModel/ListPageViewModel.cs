using CoinHybridApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CoinHybridApp.ViewModel
{
    public class ListPageViewModel
    {
        public ObservableCollection<CryptoModel> CryptoList { get; set; }

        public ListPageViewModel()
        {
            CryptoList = new ObservableCollection<CryptoModel>();
            CryptoList.Add(new CryptoModel { Name = "BTC", Image = "https://btcdirect.eu/media/42/download/bitcoin-logo.svg?v=1", Detail = "Bitcoin", Price = "4532$" });
            //you can add here multiple list items 
            CryptoList.Add(new CryptoModel { Name = "ETH", Image = "https://btcdirect.eu/media/42/download/bitcoin-logo.svg?v=1", Detail = "Etherum", Price = "234$" });

        }
    }
}
