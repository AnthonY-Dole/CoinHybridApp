using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinHybridApp.Models
{
  public class BuySellModel
    {
        [PrimaryKey, Column("ID"), AutoIncrement]
        public int ID { get; set; }
        [Column("Name")]
        public string Name { get; set; }

        [Column("Wallet")] 
        public string Wallet { get; set; }
        [Column("PriceUsd")]
        public string PriceUsd { get; set; }
        [Column("ImageUrl")]
        public string ImageUrl { get; set; }
        public BuySellModel()
        {

        }
        public BuySellModel(string PName, string Pprice,string PWallet, string PImage)
        {
            Name = PName;

            PriceUsd = Pprice;
            Wallet = PWallet;
            ImageUrl = PImage;

        }
    }
}
