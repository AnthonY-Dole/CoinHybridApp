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

        private async void ButtonCreate_Clicked(object sender, EventArgs e)
        {
            string Name = this.FindByName<Entry>("Name").Text;
            string Abrev = this.FindByName<Entry>("Abrev").Text;
            string Price = this.FindByName<Entry>("Price").Text;
            string Circ = this.FindByName<Entry>("Circ").Text;
            string Max = this.FindByName<Entry>("Max").Text;
            string Det = this.FindByName<Editor>("Det").Text;

            if (Name == "" || Abrev == "" || Price == ""|| Circ == "" || Max == "" || Det == "")
            {
                await DisplayAlert("Alert", "Make sure to complete all entry.", "OK");
            }
            else if(Convert.ToDecimal(Circ) > Convert.ToDecimal(Max))
            {
                await DisplayAlert("Alert", "Circulating supply can't exceed max supply.", "OK");
            }
            else if(Abrev.Count() > 4)
            {
                await DisplayAlert("Alert", "Abbreviation can't exceed 4 characters.", "OK");

            }
            else
            {
                VM.newAsset();
                this.FindByName<Entry>("Name").Text = string.Empty;
                this.FindByName<Entry>("Abrev").Text = string.Empty;
                this.FindByName<Entry>("Price").Text = string.Empty;
                this.FindByName<Entry>("Circ").Text = string.Empty;
                this.FindByName<Entry>("Max").Text = string.Empty;
                this.FindByName<Editor>("Det").Text = string.Empty;
            }
        }

        private async void ButtonList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreatedAssetList());
        }
    }
}