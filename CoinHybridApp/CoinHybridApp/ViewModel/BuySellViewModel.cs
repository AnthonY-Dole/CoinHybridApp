using CoinHybridApp.DAL;
using CoinHybridApp.Extensions;
using CoinHybridApp.Models;
using CoinHybridApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace CoinHybridApp.ViewModel
{
	public class BuySellViewModel : BaseViewModel
	{
        BuySellModel Asset = new BuySellModel();
        public ObservableCollection<CryptocurencyModel> Cryptos { get; set; }
        ObservableCollection<BuySellModel> buyAssets = new ObservableCollection<BuySellModel>();

       //Property Binding
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


        string date;
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                if (date != value)
                {
                    date = value;
                    OnPropertyChanged();
                }
            }
        }
        BuySellModel _isSelected;
        public BuySellModel SelectedMe
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged("SelectedMe");
                    CallView();
                }
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
        public void CallView()
        {

            Device.BeginInvokeOnMainThread(() =>
            {
                MessagingCenter.Send(this, "CallViewFromViewModel");
            });
        }
        public BuySellViewModel()
        {
            this.Cryptos = new ObservableCollection<CryptocurencyModel>();
            BuyList();
        }
        //Create list with cryptocurrency buy
        private void BuyList()
        {
            List<BuySellModel> listeBuyAsset = new List<BuySellModel>(DAL.CryptoModelDAL.GetbuyAssets());

           
            if (listeBuyAsset != null && listeBuyAsset.Any())
                buyAssets = new ObservableCollection<BuySellModel>(listeBuyAsset);
        
        }
        //Buy cryptocurrency 
        public void newBuy()
        {
            if(PriceUsd != null)
            {
                var test = float.Parse(PriceUsd);
                var test2 = float.Parse(SelectedCrypto.PriceUsd.Replace("$", ""), CultureInfo.InvariantCulture.NumberFormat);
                float yourbuy = test / test2;
                DateTime localDate = DateTime.Now;
                Date = localDate.ToString();

                BuySellModel BuyAsset = new BuySellModel(selectedCrypto.Name, PriceUsd, yourbuy.ToString(), SelectedCrypto.ImageUrl, Date);
                //Add data for push on sqlite
                CryptoModelDAL.InsertIfNotExistS(BuyAsset);
                //Push data on sqlite

            }
          
         
        }
        //Refresh data list for the view
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
        //Delete asset item list when click and accept
        public void DoSomething()
        {

            Asset = SelectedMe;
            CryptoModelDAL.DeleteBuyAsset(Asset);
        }
        //Async task for add data in the picker view
        public async Task UpdateAssetsLimitAsync()
        {
            //for refreshing data
            if (IsBusy) return;
            IsBusy = true;
            //call the method for the asset
            var newPosts = await HttpService.GetAssetsLimitAsync();
            Cryptos.Clear();
            //push each data
            newPosts.ForEach((post) =>
            {
                //trim data for visibility
                var price = post.PriceUsd.Substring(0, post.PriceUsd.IndexOf(".") + 4);
                var changePercent = post.ChangePercent24Hr.Substring(0, post.ChangePercent24Hr.IndexOf(".") + 4);
                //Add image with our image server with the correct symbol 
                post.ImageUrl = "https://res.cloudinary.com/anvukekorp/image/upload/icon/" + post.Symbol.ToLower();
                post.PriceUsd = price + '$';
                post.ChangePercent24Hr = changePercent + '%';
                //Add the data on the Observable collection Cryptos
                Cryptos.Add(post);

            });
            IsBusy = false;
        }
    }
}

