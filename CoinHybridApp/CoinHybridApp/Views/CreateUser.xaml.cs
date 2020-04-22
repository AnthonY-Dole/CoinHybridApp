﻿using CoinHybridApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinHybridApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoinHybridApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateUser : ContentPage
    {

        CreateUserViewModel VM;
        public CreateUser()
        {
            InitializeComponent();
            Title = "Créer un profil";
            VM = new CreateUserViewModel();
            this.BindingContext = VM;
        }

        private void createUser(object sender, EventArgs e)
        {
            VM.newUser();
            Navigation.PopAsync();
        }
    }
}