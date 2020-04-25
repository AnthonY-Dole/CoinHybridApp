using CoinHybridApp.DAL;
using CoinHybridApp.Extensions;
using CoinHybridApp.Models;
using CoinHybridApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace CoinHybridApp.ViewModel
{
	public class BuySellViewModel : BaseViewModel
	{
	
		public ObservableCollection<CryptocurencyModel> Cryptos { get; set; }
        ObservableCollection<BuySellModel> buyAssets = new ObservableCollection<BuySellModel>();
        public ObservableCollection<BuySellModel> BuyAssets
        {
            get { return buyAssets; }
            set
            {
                SetProperty(ref buyAssets, value);
            }
        }
        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                SetProperty(ref name, value);
            }
        }

       

        string priceusd;
        public string PriceUsd
        {
            get
            {
                return priceusd;
            }
            set
            {
                SetProperty(ref priceusd, value);
            }
        }

   


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
            BuyList();
        }
        private void BuyList()
        {
            List<BuySellModel> listeBuyAsset = new List<BuySellModel>(DAL.CryptoModelDAL.GetbuyAssets());


            if (listeBuyAsset != null && listeBuyAsset.Any())
                buyAssets = new ObservableCollection<BuySellModel>(listeBuyAsset);
        }
        public void newBuy()
        {
            var test = float.Parse(PriceUsd);
            var test2 = float.Parse(SelectedCrypto.PriceUsd.Replace("$",""), CultureInfo.InvariantCulture.NumberFormat);
            float yourbuy = test / test2;

            BuySellModel BuyAsset = new BuySellModel(selectedCrypto.Name, PriceUsd , yourbuy.ToString(),SelectedCrypto.ImageUrl);

            CryptoModelDAL.InsertIfNotExistS(BuyAsset);
         
        }
        public void RefreshData()
        {
            if (IsBusy) return;
            List<BuySellModel> listeBuyAsset = new List<BuySellModel>(DAL.CryptoModelDAL.GetbuyAssets());

            if (listeBuyAsset != null && listeBuyAsset.Any())
            {
                buyAssets.Clear();
                buyAssets.AddRange(listeBuyAsset);
            }
            IsBusy = false;
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

