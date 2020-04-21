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
    public partial class Page4 : ContentPage
    {
        CreateCryptoViewModel VM;
        public Page4()
        {
            InitializeComponent();
            VM = new CreateCryptoViewModel();
            this.BindingContext = VM;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            VM.newAsset();
            Navigation.PopAsync();
        }
    }
}