using CoinHybridApp.DAL;
using CoinHybridApp.Extensions;
using CoinHybridApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace CoinHybridApp.ViewModel
{
    public class CreatedAssetListViewModel : BaseViewModel
    {
        ObservableCollection<CryptoModel> assets = new ObservableCollection<CryptoModel>();
        public ObservableCollection<CryptoModel> Assets
        {
            get { return assets; }
            set
            {
                SetProperty(ref assets, value);
            }
        }

        public CreatedAssetListViewModel()
        {
            init();
           
        }

        private void init()
        {
            List<CryptoModel> listeAsset = new List<CryptoModel>(DAL.CryptoModelDAL.GetAssets());


            if (listeAsset != null && listeAsset.Any())
                assets = new ObservableCollection<CryptoModel>(listeAsset);
        }

        public void RefreshData()
        {
            List<CryptoModel> listeAsset = new List<CryptoModel>(DAL.CryptoModelDAL.GetAssets());

            if (listeAsset != null && listeAsset.Any())
            {
                assets.Clear();
                assets.AddRange(listeAsset);
            }
        }

    }
}

