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
using Xamarin.Forms;

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
        private string _textError;
        public string TextError
        {
            get { return _textError; }
            set
            {
                SetProperty(ref _textError, value);
            }
        }
        public ICommand Hour { get; private set; }
        public ICommand Day { get; private set; }
        public ICommand Minute { get; private set; }
        public ICommand Month { get; private set; }



        public ListPageDetailViewModel(CryptocurencyModel detail)
        {
            this.Detail = detail;
            this.Cryptos = new ObservableCollection<CryptocurencyModel>();
            Hour = new Command
              (async () => await UpdateValuesChartAsync("h1"));
            Day = new Command
             (async () => await UpdateValuesChartAsync("d1"));
            Minute = new Command
           (async () => await UpdateValuesChartAsync("m1"));
            Day = new Command
             (async () => await UpdateValuesChartAsync("d1"));
        }
     
        public async Task UpdateValuesChartAsync(string time)
        {
           var DatailName = this.Detail.Name.ToLower();
            var asset = DatailName.Replace(' ', '-');
            if (IsBusy) return;
            IsBusy = true;
            var newChart = await HttpService.GetValuesChartAsync(asset, time);

                this.Cryptos.Clear();
                List<string> coinPrices = newChart.Select(x => x.PriceUsd).ToList();
                List<Microcharts.Entry> entries = new List<Microcharts.Entry>();
                int takeData = 0;
                foreach (string price in coinPrices)
                {
                    takeData++;

                Microcharts.Entry newentry = new Microcharts.Entry(float.Parse(price, CultureInfo.InvariantCulture.NumberFormat))
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
            string hightPrices = coinPrices.Max();
            try {
               if(entries.Count > 1)
                {
                    this.Chart = new LineChart()
                    {
                        Entries = entries,
                        LineMode = LineMode.Straight,
                        LineSize = 4f,
                        MinValue = (float.Parse(lowestPrices.ToString(), CultureInfo.InvariantCulture.NumberFormat)),
                        PointMode = PointMode.None,
                        MaxValue = (float.Parse(hightPrices.ToString(), CultureInfo.InvariantCulture.NumberFormat)),

                    };
                }
                else
                {
                    TextError = "Ah! aucun Graphique disponible";
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            IsBusy = false;
        }    
        }     
}