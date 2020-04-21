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
    public partial class CreateCrypto : ContentPage
    {
        CreateCryptoViewModel VM;
        public CreateCrypto()
        {
            InitializeComponent();
            VM = new CreateCryptoViewModel();
            this.BindingContext = VM;
        }

        private void ButtonCreate_Clicked(object sender, EventArgs e)
        {
            VM.newAsset();
            Navigation.PopAsync();
        }

        private async void ButtonList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreatedAssetList());
        }
    }
}