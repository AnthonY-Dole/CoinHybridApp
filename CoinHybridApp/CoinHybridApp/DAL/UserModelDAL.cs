using CoinHybridApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoinHybridApp.DAL
{
    public static class UserModelDAL
    {
        public static int InsertIfNotExist(UserModel c)
        {
            int result = 0;
            int test = 0;
            using (SQLiteConnection db = DbConnection.GetConnection())
            {
                lock (DbConnection.Locker)
                {
                    if (!db.Table<UserModel>().Any(a => a.Mail == c.Mail))
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

        public static List<UserModel> GetUsers()
        {
            List<UserModel> results = new List<UserModel>();
            using (SQLiteConnection db = DbConnection.GetConnection())
            {
                lock (DbConnection.Locker)
                {
                    results = db.Table<UserModel>().ToList();
                }
            }
            return results;
        }

        public static bool UpdateUser(UserModel c)
        {
            bool b = false;
            using (SQLiteConnection db = DbConnection.GetConnection())
            {
                lock (DbConnection.Locker)
                {
                    foreach (UserModel u in db.Table<UserModel>())
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

        public static bool DeleteUser(UserModel c)
        {
            bool b = false;
            using (SQLiteConnection db = DbConnection.GetConnection())
            {
                lock (DbConnection.Locker)
                {
                    foreach (UserModel u in db.Table<UserModel>())
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
