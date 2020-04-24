using CoinHybridApp.Models;
using CoinHybridApp.ViewModel;
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
    public partial class BuySell : ContentPage
    {
        BuySellViewModel vm;

        public BuySell()
        {
            InitializeComponent();
            vm = new BuySellViewModel();
            BindingContext = vm;
         
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await vm.UpdateAssetsLimitAsync();

        }
    }
}