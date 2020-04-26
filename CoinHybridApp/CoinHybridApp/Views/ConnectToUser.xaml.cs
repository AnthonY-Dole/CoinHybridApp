using CoinHybridApp.ViewModel;
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
        ConnectToUserViewModel VM;
        bool lancementApplication = true;
        public ConnectToUser()
        {
            InitializeComponent();
            Title = "Connexion";
            VM = new ConnectToUserViewModel();
            this.BindingContext = VM;
        }

        private void connectToUser(object sender, EventArgs e)
        {
            var mail = mailtyped.Text;
            var password = passwordtyped.Text;
            if(string.IsNullOrEmpty(mailtyped.Text))
            {
                DisplayAlert("Erreur","Le champ d'adresse mail n'a pas été rempli.","OK");
            } else
            {
                if(string.IsNullOrEmpty(passwordtyped.Text))
                {
                    DisplayAlert("Erreur", "Le champ du mot de passe n'a pas été rempli.", "OK");
                } else
                {
                    VM.connectToUser(mail, password);
                    Navigation.PopAsync();
                }
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(lancementApplication)
            {
                lancementApplication = false;
            } 
            else
            {
                VM.RefreshData();
            }
        }
    }
}