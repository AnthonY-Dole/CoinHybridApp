using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CoinHybridApp.Extensions
{
    public static class ObservableCollectionExtension
    {
        public static void AddRange<T>(this ObservableCollection<T> ts, List<T> liste)
        {
            if (liste != null && liste.Any())
            {
                liste.ForEach((a) => ts.Add(a));
            }
        }
    }
}
