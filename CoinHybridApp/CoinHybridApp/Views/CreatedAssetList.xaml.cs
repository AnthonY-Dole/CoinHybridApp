using CoinHybridApp.Models;
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
    public partial class CreatedAssetList : ContentPage
    {
        CreatedAssetListViewModel VM;
        bool lancementApplication = true;
        public CreatedAssetList()
        {
            InitializeComponent();
            VM = new CreatedAssetListViewModel();
            this.BindingContext = VM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (lancementApplication)
            {
                lancementApplication = false;
            }
            else
            {
                VM.RefreshData();
            }
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            CryptoModel Asset = null;
            var b = (Button)sender;

            var ob = b.BindingContext as CryptoModel;

            if (ob != null)

            {

                Asset = ob;

            }

            VM.DeleteCrypto(Asset);
            VM.RefreshData();
        }
    }
}