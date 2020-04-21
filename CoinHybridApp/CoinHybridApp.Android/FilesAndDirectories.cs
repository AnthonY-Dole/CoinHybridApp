using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CoinHybridApp.Droid;
using CoinHybridApp.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(FilesAndDirectories))]
namespace CoinHybridApp.Droid
{
    public class FilesAndDirectories : IFilesAndDirectories
    {
        string AppPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // path vers le répertoire de l'application.

        /// <summary>
        /// Nom de la base de données
        /// </summary>
        string nomBDD = "database.CoinHybridAPP";

        /// <summary>
        /// Retourne le path vers la base de données
        /// </summary>
        /// <returns></returns>
        public string GetBDDPath()
        {
            return Path.Combine(AppPath, nomBDD);
        }
    }
}