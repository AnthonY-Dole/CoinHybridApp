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
        public CreateUser()
        {
            InitializeComponent();
            Title = "Créer un profil";
        }

        private void createUser(object sender, EventArgs e)
        {
        }
    }
}