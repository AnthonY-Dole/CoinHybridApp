using CoinHybridApp.Models;
using CoinHybridApp.ViewModel;
using CoinHybridApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoinHybridApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
            var vm = new ListPageViewModel();
            BindingContext = vm;

        }
        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as CryptocurencyModel;
            await Navigation.PushAsync(new ListPageDetail(mydetails.Name, mydetails.PriceUsd, mydetails.Symbol,mydetails.ChangePercent24Hr,mydetails.VolumeUsd24Hr,mydetails.MarketCapUsd,mydetails.Supply));

        }
    }
}