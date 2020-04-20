﻿using CoinHybridApp.Models;
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
        ListPageViewModel vm;
        public ListPage()
        {
            InitializeComponent();
             vm = new ListPageViewModel();
            BindingContext = vm;

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await vm.UpdateAssetsAsync();
        }

   
        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
            {
             var mydetails = e.Item as CryptocurencyModel;
             await Navigation.PushAsync(new ListPageDetail(mydetails.Name, mydetails.PriceUsd, mydetails.Symbol,mydetails.ChangePercent24Hr,mydetails.VolumeUsd24Hr,mydetails.MarketCapUsd,mydetails.Supply,mydetails.ImageUrl));

            }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _container = BindingContext as ListPageViewModel;
            CryptoListView.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                CryptoListView.ItemsSource = _container.Cryptos;
            else
                CryptoListView.ItemsSource = _container.Cryptos.Where(i => i.Name.Contains(e.NewTextValue));

            CryptoListView.EndRefresh();
        }
    }
}