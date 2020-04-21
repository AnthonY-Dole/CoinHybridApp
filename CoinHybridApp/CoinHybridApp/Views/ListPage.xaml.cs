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

   
       
        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var postDetailPage = new ListPageDetail(e.SelectedItem as CryptocurencyModel);
            await Navigation.PushAsync(postDetailPage);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _container = BindingContext as ListPageViewModel;
            CryptoListView.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                CryptoListView.ItemsSource = _container.Cryptos;
            else
                CryptoListView.ItemsSource = _container.Cryptos.Where(i => i.Name.ToLower().Contains(e.NewTextValue.ToLower()));

            CryptoListView.EndRefresh();
        }

     
    }
}