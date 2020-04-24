using CoinHybridApp.DAL;
using CoinHybridApp.Extensions;
using CoinHybridApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CoinHybridApp.ViewModel
{
    public class ConnectToUserViewModel : BaseViewModel
    {
        ObservableCollection<UserModel> users = new ObservableCollection<UserModel>();

        public ObservableCollection<UserModel> Users
        {
            get
            { 
                return users; 
            }
            set
            {
                SetProperty(ref users, value);
            }
        }

        public ConnectToUserViewModel()
        {
            init();
        }

        private void init()
        {
            List<UserModel> listeUser = new List<UserModel>(DAL.UserModelDAL.GetUsers());

            if(listeUser != null && listeUser.Any())
            {
                users = new ObservableCollection<UserModel>(listeUser);
            }
        }

        public void RefreshData()
        {
            List<UserModel> listeUser = new List<UserModel>(DAL.UserModelDAL.GetUsers());

            if(listeUser != null && listeUser.Any())
            {
                users.Clear();
                users.AddRange(listeUser);
            }
        }

        public void connectToUser(string mail, string password)
        {
            RefreshData();
            DAL.UserModelDAL.TryToConnect(mail, password);
        }
    }
}
