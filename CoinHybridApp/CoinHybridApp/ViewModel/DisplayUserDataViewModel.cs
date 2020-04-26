using CoinHybridApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinHybridApp.ViewModel
{
    public class DisplayUserDataViewModel : BaseViewModel
    {
        UserModel u = new UserModel();
        public UserModel U
        {
            get
            {
                return u;
            }
            set
            {
                SetProperty(ref u, value);
            }
        }

        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                SetProperty(ref name, value);
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

        public void refresh()
        {
            u = data.currentUser;
            Console.WriteLine(data.currentUser.Name.ToString());
        }

        public DisplayUserDataViewModel(UserModel user)
        {
            u = user;
            Name = user.Name;
            Money = user.Money;
        }
    }
}
