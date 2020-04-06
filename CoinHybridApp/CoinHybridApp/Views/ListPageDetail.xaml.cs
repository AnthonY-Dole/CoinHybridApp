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
        public ListPageDetail(string Name,string Price,string source)
        {
            InitializeComponent();
            MyItemNameShow.Text = Name;
            MypriceItemShow.Text = Price;
            MyImageCell.Source = new UriImageSource()
            {
                Uri = new Uri(source)
            };
        }
    }
}