using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinHybridApp.Models
{
    public class UserModel
    {
        [PrimaryKey, Column("ID"), AutoIncrement]
        public int ID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Mail")]
        public string Mail { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("Image")]
        public string Image { get; set; }

        [Column("Money")]
        public string Money { get; set; }

        public UserModel()
        {

        }

        public UserModel(string PName, string PMail, string PPassword, string PImage, string PMoney)
        {
            Name = PName;
            Mail = PMail;
            Password = PPassword;
            Image = PImage;
            Money = PMoney;
        }

    }
}
