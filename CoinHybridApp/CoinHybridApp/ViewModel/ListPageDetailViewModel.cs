using CoinHybridApp.Models;
using CoinHybridApp.Service;
using Microcharts;
using Newtonsoft.Json;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace CoinHybridApp.ViewModel
{
    public class ListPageDetailViewModel : BaseViewModel
    {
        public ObservableCollection<CryptocurencyModel> Cryptos { get; set; }
        private Chart _chart;
        public Chart Chart
        {
            get { return _chart; }
            set
            {
                SetProperty(ref _chart, value);
            }
        }


        public ListPageDetailViewModel()
        {
          
            this.Cryptos = new ObservableCollection<CryptocurencyModel>();
        }

        public async Task UpdateValuesChartAsync()
        {

            var newChart = await HttpService.GetValuesChartAsync();
            this.Cryptos.Clear();
            List<string> coinPrices = newChart.Select(x => x.PriceUsd).ToList();
            List<Entry> entries = new List<Entry>();
            int takeData = 0;
            foreach (string price in coinPrices)
            {
                takeData++;

                Entry newentry = new Entry(float.Parse(price, CultureInfo.InvariantCulture.NumberFormat))
                {
                    Color = SKColor.Parse("#3498db"),
                };

                if (takeData == 2)
                {
                    entries.Add(newentry);
                    takeData = 0;
                }

            }
            string lowestPrices = coinPrices.Min();
            
            this.Chart = new LineChart()
            {
                Entries = entries,
                LineMode = LineMode.Straight,
                LineSize = 4f,
                MinValue = (float.Parse(lowestPrices.ToString(), CultureInfo.InvariantCulture.NumberFormat)),
                PointMode = PointMode.None
            
        };
           
         
         
          
        }
        /*
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

                    Entry newentry = new Entry(float.Parse(price, CultureInfo.InvariantCulture.NumberFormat))
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
                var chart = new LineChart() { Entries = entries, LineMode = LineMode.Straight, LineSize = 2f, MinValue = (float.Parse(lowestPrices.ToString(), CultureInfo.InvariantCulture.NumberFormat)), PointMode = PointMode.None };
                return JsonConvert.DeserializeObject<ApiResult>(data).CryptosChart;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
      
       */

    }
}