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
            BindingContext = new ListPageViewModel();
        }
        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as CryptoModel;
            await Navigation.PushAsync(new ListPageDetail(mydetails.Name, mydetails.Price, mydetails.Image));

        }
    }
}