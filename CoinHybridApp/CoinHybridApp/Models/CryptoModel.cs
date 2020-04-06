using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinHybridApp.Models
{
    public class CryptoModel
    {
        [PrimaryKey, Column("ID"), AutoIncrement]
        public int ID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Abreviation")]
        public string Abreviation { get; set; }

        [Column("Detail")]
        public string Detail { get; set; }

        [Column("Logo")]
        public string Image { get; set; }

        [Column("Price")]
        public string Price { get; set; }

        [Column("MaxSupply")]
        public string MaxSupply { get; set; }

        [Column("CirculatingSupply")]
        public string CirculatingSupply { get; set; }

        [Column("Capitalisation")]
        public string Capitalisation { get; set; }

        public CryptoModel()
        {

        }

        public CryptoModel(string PName, string PAbrev, string Pdetail, string PImage, string Pprice, string PmaxSupply, string PcirculatingSupply)
        {
            Name = PName;
            Abreviation = PAbrev;
            Detail = Pdetail;
            Image = PImage;
            Price = Pprice;
            MaxSupply = PmaxSupply;
            CirculatingSupply = PcirculatingSupply;
            Capitalisation = (Convert.ToInt32(Pprice) * Convert.ToInt32(PcirculatingSupply)).ToString();
        }

    }
}
