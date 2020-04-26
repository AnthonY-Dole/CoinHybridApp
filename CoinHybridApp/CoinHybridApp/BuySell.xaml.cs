using Acr.UserDialogs;
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


        public async void HandleConfirmation(BuySellViewModel sender)
        {
           if(vm.SelectedCrypto.Name != null)
            {
                var config = new ConfirmConfig()
                {
                    Title = "Revendre?",
                    Message = "Voulez vous revendre du " + vm.SelectedCrypto.Name + "qui vaut " + vm.SelectedCrypto.PriceUsd + "$ ?",
                    OkText = "Oui",
                    CancelText = "Non",
                };
                if (await UserDialogs.Instance.ConfirmAsync(config))
                {
                    vm.DoSomething();
                }
            }
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await vm.UpdateAssetsLimitAsync();
            MessagingCenter.Subscribe<BuySellViewModel>(this, "CallViewFromViewModel", HandleConfirmation);

        }
       

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<BuySellViewModel>(this, "CallViewFromViewModel");
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            vm.newBuy();
            Navigation.PopAsync();
            vm.RefreshData();
        }

       
     
    }
}