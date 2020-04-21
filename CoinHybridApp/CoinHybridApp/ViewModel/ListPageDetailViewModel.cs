using CoinHybridApp.Models;
using CoinHybridApp.Service;
using CoinHybridApp.Views;
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
using System.Windows.Input;


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
        private CryptocurencyModel _detail;
        public CryptocurencyModel Detail
        {
            get => _detail;
            set
            {
                SetProperty(ref _detail, value);
            }
        }

       

        public ListPageDetailViewModel(CryptocurencyModel detail)
        {
            this.Detail = detail;
            this.Cryptos = new ObservableCollection<CryptocurencyModel>();
        }
     
        public async Task UpdateValuesChartAsync()
        {
            var asset = this.Detail.Name.ToLower();
            
            var newChart = await HttpService.GetValuesChartAsync(asset, "h1");
            
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

        
    }
}