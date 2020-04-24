﻿using CoinHybridApp.ViewModel;
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
    public partial class ConnectToUser : ContentPage
    {
        CreateUserViewModel VM;
        public ConnectToUser()
        {
            InitializeComponent();
            Title = "Connexion";
            VM = new CreateUserViewModel();
            this.BindingContext = VM;
        }

        private void connectToUser(object sender, EventArgs e)
        {
            var mail = mailtyped.Text;
            var password = passwordtyped.Text;


        }
    }
}