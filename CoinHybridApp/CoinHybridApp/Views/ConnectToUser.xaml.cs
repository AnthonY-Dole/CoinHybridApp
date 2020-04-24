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

            VM.connectToUser(mail, password);
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