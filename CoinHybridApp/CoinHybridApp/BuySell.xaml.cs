using CoinHybridApp.Controls;
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
            button1.Clicked += button1_Clicked;
            BindingContext = vm;
         
        }
        private void button1_Clicked(object sender, EventArgs e)
        {
            borderlessPicker1.Focus();
        }

        

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await vm.UpdateAssetsLimitAsync();

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            vm.newBuy();
            Navigation.PopAsync();
            vm.RefreshData();
        }

       
     
    }
}