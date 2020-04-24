using System;
using System.Collections.Generic;
using System.Text;

namespace CoinHybridApp.Models
{
   public  class CryptoData
    {
		public static IList<CryptocurencyModel> Monkeys { get; private set; }

		static CryptoData()
		{
			Monkeys = new List<CryptocurencyModel>();

			Monkeys.Add(new CryptocurencyModel
			{
				Name = "Baboon",
				PriceUsd = "Africa & Asia",
				Symbol = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
				ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
			});
			Monkeys.Add(new CryptocurencyModel
			{
				Name = "zefzef",
				PriceUsd = "Africa & Asia",
				Symbol = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
				ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
			});
			Monkeys.Add(new CryptocurencyModel
			{
				Name = "Baboon",
				PriceUsd = "Africa & Asia",
				Symbol = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
				ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
			});


		}
	}
}
