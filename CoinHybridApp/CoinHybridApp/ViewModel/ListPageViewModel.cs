using CoinHybridApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace CoinHybridApp.ViewModel
{
    public class ListPageViewModel : BaseViewModel
    {
        ObservableCollection<CryptocurencyModel> _cryptos;
        public ObservableCollection<CryptocurencyModel> Cryptos
        {
            get
            {
                if (_cryptos == null)
                {
                    _cryptos = new ObservableCollection<CryptocurencyModel>();
                }
                return _cryptos;
            }
            set
            {
                if (value != _cryptos)
                {
                    _cryptos = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }
        public ICommand RefreshCommand
        {
            get {
                return new Command(async () =>
                {
                    IsRefreshing = true;
                        var crypto = await GetCryptoAssets();
                        crypto.ForEach(Cryptos.Add);
                  
                    IsRefreshing = false;
                });
            }
        }
        public ListPageViewModel()
        {
            Task.Run(async () =>
            {
                var crypto = await GetCryptoAssets();
                crypto.ForEach(Cryptos.Add);
                Debug.WriteLine(Cryptos);
            });
        }

        private async Task<IEnumerable<CryptocurencyModel>> GetCryptoAssets()
        {
            var client = new HttpClient();
            try
            {
                IsBusy = true;
                var data = await client.GetStringAsync("https://api.coincap.io/v2/assets");
                IsBusy = false;
                return JsonConvert.DeserializeObject<ApiResult>(data).Cryptos;
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