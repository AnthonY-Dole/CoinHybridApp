using CoinHybridApp.Models;
using CoinHybridApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace CoinHybridApp.ViewModel
{
	public class BuySellViewModel : BaseViewModel
	{
		public IList<CryptocurencyModel> Monkeys { get { return CryptoData.Monkeys; } }
		public ObservableCollection<CryptocurencyModel> Cryptos { get; set; }

		

		CryptocurencyModel selectedCrypto;
		public CryptocurencyModel SelectedCrypto
        {
			get { return selectedCrypto; }
			set
			{
				if (selectedCrypto != value)
				{
					selectedCrypto = value;
					OnPropertyChanged();
				}
			}
		}
        public BuySellViewModel()
        {
            this.Cryptos = new ObservableCollection<CryptocurencyModel>();
        }

        public async Task UpdateAssetsLimitAsync()
        {
            if (IsBusy) return;
            IsBusy = true;
            var newPosts = await HttpService.GetAssetsLimitAsync();
            Cryptos.Clear();
            newPosts.ForEach((post) =>
            {
                var price = post.PriceUsd.Substring(0, post.PriceUsd.IndexOf(".") + 4);
                var changePercent = post.ChangePercent24Hr.Substring(0, post.ChangePercent24Hr.IndexOf(".") + 4);
                post.ImageUrl = "https://res.cloudinary.com/anvukekorp/image/upload/icon/" + post.Symbol.ToLower();
                post.PriceUsd = price + '$';
                post.ChangePercent24Hr = changePercent + '%';
                Cryptos.Add(post);

            });
            IsBusy = false;
        }
    }
}

