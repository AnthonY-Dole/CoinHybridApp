using CoinHybridApp.Models;
using CoinHybridApp.Service;
using CoinHybridApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace CoinHybridApp.ViewModel
{
    public class ListPageViewModel : BaseViewModel
    {
        public ObservableCollection<CryptocurencyModel> Cryptos { get; set; }
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
                       await UpdateAssetsAsync();
                      
                    IsRefreshing = false;
                });
            }
        }
        public ListPageViewModel()
        {
            this.Cryptos = new ObservableCollection<CryptocurencyModel>();
        }
       
        public static string Convertion(string n)
        {

            float result = float.Parse(n, CultureInfo.InvariantCulture.NumberFormat);
            Console.WriteLine(result);
            if (result < 1000)
                return result.ToString();

            if (result < 10000)
                return String.Format("{0:#,.##}K", result - 5);

            if (result < 100000)
                return String.Format("{0:#,.#}K", result - 50);

            if (result < 1000000)
                return String.Format("{0:#,.}K", result - 500);

            if (result < 10000000)
                return String.Format("{0:#,,.##}M", result - 5000);

            if (result < 100000000)
                return String.Format("{0:#,,.#}M", result - 50000);

            if (result < 1000000000)
                return String.Format("{0:#,,.}M", result - 500000);

            return String.Format("{0:#,,,.##}B", result - 5000000);
        }
        public async Task UpdateAssetsAsync()
        {
            if (IsBusy) return;
            IsBusy = true;
            var newPosts = await HttpService.GetAssetsAsync();
            this.Cryptos.Clear();
            newPosts.ForEach((post) =>
            {
                var price = post.PriceUsd.Substring(0, post.PriceUsd.IndexOf(".") + 4);
                var changePercent = post.ChangePercent24Hr.Substring(0, post.ChangePercent24Hr.IndexOf(".") + 4);
                post.ImageUrl = "https://res.cloudinary.com/anvukekorp/image/upload/icon/" + post.Symbol.ToLower();
                post.PriceUsd = price + '$';
                post.Supply = Convertion(post.Supply);
               post.MarketCapUsd = Convertion(post.MarketCapUsd);
               post.VolumeUsd24Hr = Convertion(post.VolumeUsd24Hr);
              
                post.ChangePercent24Hr = changePercent + '%';
                this.Cryptos.Add(post);

            });
            IsBusy = false;
        }
    }

}