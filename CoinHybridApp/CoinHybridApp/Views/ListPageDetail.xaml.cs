using CoinHybridApp.Models;
using CoinHybridApp.ViewModel;
using Microcharts;
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
    public partial class ListPageDetail : ContentPage
    {
        ListPageDetailViewModel vm;
      

        public ListPageDetail(CryptocurencyModel detail)
        {
            InitializeComponent();
            vm = new ListPageDetailViewModel(detail);
            this.BindingContext = vm;
        }
        protected override async void OnAppearing()
        {
            
            base.OnAppearing();
            await vm.UpdateValuesChartAsync("h1");
          
        }
      
    }
}