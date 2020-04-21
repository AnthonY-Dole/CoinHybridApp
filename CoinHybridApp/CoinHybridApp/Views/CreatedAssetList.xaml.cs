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
    }
}