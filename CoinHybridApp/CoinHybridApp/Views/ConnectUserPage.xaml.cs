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
    public partial class ConnectUserPage : ContentPage
    {
        public ConnectUserPage()
        {
            InitializeComponent();
            Title = "Connexion";
        }
    }
}