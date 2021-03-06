﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinHybridApp.Models;
using CoinHybridApp.ViewModel;
using CoinHybridApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoinHybridApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        DisplayUserDataViewModel VM;
        public UserPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            VM = new DisplayUserDataViewModel(data.currentUser);
            this.BindingContext = VM;
            VM.refresh();
            base.OnAppearing();
        }

        private void createUserPage(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new CreateUser());
            });
        }

        private void connectToUserPage(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ConnectToUser());
            });
        }
    }
}