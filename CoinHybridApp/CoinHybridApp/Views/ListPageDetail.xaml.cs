using CoinHybridApp.ViewModel;
using Microcharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoinHybridApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPageDetail : ContentPage
    {
        public ListPageDetail(string Name,string PriceUsd,string Symbol,string ChangePercent24Hr,string VolumeUsd24Hr,string MarketCapUsd,string Supply)
        {
            InitializeComponent();
            BindingContext = new ListPageDetailViewModel();
            
            MyCryptoName.Text = Name;
            MyCryptoPrice.Text = PriceUsd;
             MyCryptoSymbol.Text = Symbol;
            MyCryptoChange.Text = ChangePercent24Hr;
            MyCryptoVolume.Text = VolumeUsd24Hr;
            MyCryptoMarket.Text = MarketCapUsd;
            MyCryptoSupply.Text = Supply;
        }
    }

}