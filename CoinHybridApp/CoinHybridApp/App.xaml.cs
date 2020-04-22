using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoinHybridApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Création de la BDD CoinHybridAPP si non existante.
            DAL.DbConnection.CreateDb();
            MainPage = new MainPage();
           
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
