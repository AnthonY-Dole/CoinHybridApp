using CoinHybridApp.DAL;
using CoinHybridApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinHybridApp.ViewModel
{
    public class CreateUserViewModel : BaseViewModel
    {
        string nom;
        public string Nom
        {
            get
            {
                return nom;
            }
            set
            {
                SetProperty(ref nom, value);
            }
        }

        string mail;
        public string Mail
        {
            get
            {
                return mail;
            }
            set
            {
                SetProperty(ref mail, value);
            }
        }

        string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                SetProperty(ref password, value);
            }
        }

        string image;
        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                SetProperty(ref image, value);
            }
        }

        string money;
        public string Money
        {
            get
            {
                return money;
            }
            set
            {
                SetProperty(ref money, value);
            }
        }

        public int newUser()
        {
            UserModel User = new UserModel(Nom, Mail, Password, Image, Money);
            int result = UserModelDAL.InsertIfNotExist(User);
            if (result == 0)
            {
                result = 0;
            }
            else
            {
                result = 1;
            }
            List<UserModel> listeControle = new List<UserModel>(UserModelDAL.GetUsers());
            Console.WriteLine("In newUser(), result is: " + result.ToString());
            return result;
        }
    }
}
