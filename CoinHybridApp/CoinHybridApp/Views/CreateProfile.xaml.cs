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
    public partial class CreateProfile : ContentPage
    {
        public CreateProfile()
        {
            InitializeComponent();
            Title = "Créer un profil";
        }

        private void createProfile(object sender, EventArgs e)
        {
        }
    }
}