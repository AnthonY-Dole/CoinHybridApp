using CoinHybridApp.Models;
using CoinHybridApp.Service;
using System.Collections.ObjectModel;
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

       /* private async Task<IEnumerable<CryptocurencyModel>> GetCryptoAssets()
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
        }*/

        public async Task UpdateAssetsAsync()
        {

            var newPosts = await HttpService.GetAssetsAsync();
            this.Cryptos.Clear();
            newPosts.ForEach((post) =>
            {
                var price = post.PriceUsd.Substring(0, post.PriceUsd.IndexOf(".") + 3);
                var changePercent = post.ChangePercent24Hr.Substring(0, post.PriceUsd.IndexOf(".") + 3);
                post.ImageUrl = "https://res.cloudinary.com/anvukekorp/image/upload/icon/" + post.Symbol.ToLower();
                post.PriceUsd = price + '$';
                post.ChangePercent24Hr = changePercent + '%';
                this.Cryptos.Add(post);

            });
        }
    }

}