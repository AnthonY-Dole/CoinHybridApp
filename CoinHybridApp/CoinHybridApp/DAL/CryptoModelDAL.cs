using CoinHybridApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoinHybridApp.DAL
{
    public static class CryptoModelDAL
    {
        /// <summary>
        /// Insert un objet CryptoModel en BDD
        /// </summary>
        /// <param name="c"></param>
        /// <returns>l'ID de l'enregistrement </returns>
        public static int InsertIfNotExist(CryptoModel c)
        {
            int result = 0;
            int test = 0;
            using (SQLiteConnection db = DbConnection.GetConnection())
            {
                lock (DbConnection.Locker)
                {
                    if (!db.Table<CryptoModel>().Any(a => a.Name == c.Name && a.Abreviation == c.Abreviation && a.Details == c.Details && a.Price == c.Price && a.MaxSupply == c.MaxSupply && a.CirculatingSupply == c.CirculatingSupply && a.Capitalisation == c.Capitalisation))
                    {
                        if ((test = db.Insert(c)) > 0)
                        {
                            result = c.ID;
                        }

                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Liste tous les enregistrements de la table CryptoModel
        /// </summary>
        /// <returns></returns>
        public static List<CryptoModel> GetAssets()
        {
            List<CryptoModel> results = new List<CryptoModel>();
            using (SQLiteConnection db = DbConnection.GetConnection())
            {
                lock (DbConnection.Locker)
                {
                    results = db.Table<CryptoModel>().ToList();
                }
            }
            return results;
        }

        public static bool UpdateAsset(CryptoModel c)
        {
            bool b = false;
            using (SQLiteConnection db = DbConnection.GetConnection())
            {
                lock (DbConnection.Locker)
                {
                    foreach (CryptoModel u in db.Table<CryptoModel>())
                    {
                        if (u.ID == c.ID)
                        {
                            db.Update(c);
                        }
                    }
                }
            }
            return b;
        }

        public static bool DeleteAsset(CryptoModel c)
        {
            bool b = false;
            using (SQLiteConnection db = DbConnection.GetConnection())
            {
                lock (DbConnection.Locker)
                {
                    foreach (CryptoModel u in db.Table<CryptoModel>())
                    {
                        if (u.ID == c.ID)
                        {
                            db.Delete(u);
                        }
                    }



                }
            }
            return b;
        }
    }
}
