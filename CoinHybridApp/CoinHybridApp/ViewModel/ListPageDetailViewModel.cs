using CoinHybridApp.Models;
using Microcharts;
using Newtonsoft.Json;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinHybridApp.ViewModel
{
    public class ListPageDetailViewModel : BaseViewModel
    {
       
      
        ObservableCollection<CryptocurencyModel> _cryptosCharts;
        public ObservableCollection<CryptocurencyModel> CryptosChart
        {
            get
            {
                if (_cryptosCharts == null)
                {
                    _cryptosCharts = new ObservableCollection<CryptocurencyModel>();
                }
                return _cryptosCharts;
            }
            set
            {
                if (value != _cryptosCharts)
                {
                    _cryptosCharts = value;
                    OnPropertyChanged();
                }
            }
        }


        public ListPageDetailViewModel()
        {
            Task.Run(async () =>
            {
           await GetValuesChartAsync();
              
            });
        }
        private async Task<IEnumerable<CryptocurencyModel>> GetValuesChartAsync()
        {
            var client = new HttpClient();
          
            try
            {
                IsBusy = true;
                var data = await client.GetStringAsync("https://api.coincap.io/v2/assets/bitcoin/history?interval=d1");
                IsBusy = false;
              
                var chartData = JsonConvert.DeserializeObject<ApiResult>(data).CryptosChart;
                List<string> coinPrices = chartData.Select(x => x.PriceUsd).ToList();
                List<Entry> entries = new List<Entry>();
                int takeData = 0;
                foreach (string price in coinPrices)
                {
                    takeData++;

                    Entry newentry = new Entry(float.Parse(price))
                    {
                        Color = SKColor.Parse("#f7931a"),
                    };

                    if (takeData == 2)
                    {
                        entries.Add(newentry);
                        takeData = 0;
                    }

                }
                string lowestPrices = coinPrices.Min();
                var chart = new LineChart() { Entries = entries, LineMode = LineMode.Straight, LineSize = 2f, MinValue = float.Parse(lowestPrices.ToString()), PointMode = PointMode.None };
              
                return JsonConvert.DeserializeObject<ApiResult>(data).CryptosChart;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
      
       

    }
}