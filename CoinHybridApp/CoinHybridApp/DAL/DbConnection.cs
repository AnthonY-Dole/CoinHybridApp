using CoinHybridApp.Interfaces;
using CoinHybridApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CoinHybridApp.DAL
{
    public static class DbConnection
    {
        public static object Locker = new object();


        /// <summary>
        /// Retourne la connexion à la BDD
        /// </summary>
        /// <returns></returns>
        public static SQLiteConnection GetConnection()
        {
            SQLiteConnection db = null;
            string dbPath = DependencyService.Get<IFilesAndDirectories>().GetBDDPath();
            db = new SQLiteConnection(dbPath);
            return db;
        }

        /// <summary>
        /// Création de la base de données.
        /// Ajouter ici les tables à créer.
        /// Cette méthode doit être appelé au démarrage de l'application
        /// </summary>
        public static void CreateDb()
        {
            using (SQLiteConnection db = GetConnection())
            {
                lock (Locker)
                {
                    db.CreateTable<CryptoModel>();
                    db.CreateTable<BuySellModel>();
                }
            }
        }
     
        public static void CreateUserDb()
        {
            using (SQLiteConnection db = GetConnection())
            {
                lock (Locker)
                {
                    db.CreateTable<UserModel>();
                }
            }
        }
    }
}
