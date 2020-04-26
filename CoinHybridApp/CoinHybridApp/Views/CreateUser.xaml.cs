using CoinHybridApp.ViewModel;
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
    public partial class CreateUser : ContentPage
    {

        CreateUserViewModel VM;
        public CreateUser()
        {
            InitializeComponent();
            Title = "Créer un profil";
            VM = new CreateUserViewModel();
            this.BindingContext = VM;
        }

        private void createUser(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nametyped.Text))
            {
                DisplayAlert("Erreur", "Le champ du nom n'a pas été rempli.", "OK");
            } else
            {
                if (string.IsNullOrEmpty(mailtyped.Text))
                {
                    DisplayAlert("Erreur", "Le champ d'adresse mail n'a pas été rempli.", "OK");
                }
                else
                {
                    if(string.IsNullOrEmpty(passwordtyped.Text))
                    {
                        DisplayAlert("Erreur", "Le champ du mot de passe n'a pas été rempli.", "OK");
                    }
                    else
                    {
                        if(string.IsNullOrEmpty(moneytyped.Text))
                        {
                            DisplayAlert("Erreur", "Le champ du solde n'a pas été rempli.", "OK");
                        }
                        else
                        {
                            int result = VM.newUser();
                            if (result == 0)
                            {
                                DisplayAlert("Erreur", "Ce compte existe déjà à cette adresse mail.", "OK");
                            }
                            else
                            {
                                Navigation.PopAsync();
                            }
                        }
                    }
                }
            }
        }
    }
}