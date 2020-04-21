using CoinHybridApp.DAL;
using CoinHybridApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinHybridApp.ViewModel
{
    public class CreateCryptoViewModel : BaseViewModel
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

        string abrev;
        public string Abrev
        {
            get
            {
                return abrev;
            }
            set
            {
                SetProperty(ref abrev, value);
            }
        }

        string photo;
        public string Photo
        {
            get
            {
                return photo;
            }
            set
            {
                SetProperty(ref photo, value);
            }
        }

        string price;
        public string Price
        {
            get
            {
                return price;
            }
            set
            {
                SetProperty(ref price, value);
            }
        }

        string circuSpply;
        public string CircuSupply
        {
            get
            {
                return circuSpply;
            }
            set
            {
                SetProperty(ref circuSpply, value);
            }
        }

        string maxSupply;
        public string MaxSupply
        {
            get
            {
                return maxSupply;
            }
            set
            {
                SetProperty(ref maxSupply, value);
            }
        }

        string details;
        public string Details
        {
            get
            {
                return details;
            }
            set
            {
                SetProperty(ref details, value);
            }
        }

        public void newAsset()
        {
            CryptoModel Asset = new CryptoModel(Nom, Abrev, Details, "", Price, MaxSupply, CircuSupply);

            CryptoModelDAL.InsertIfNotExist(Asset);
            List<CryptoModel> listeControle = new List<CryptoModel>(CryptoModelDAL.GetAssets());
        }


    }
}

