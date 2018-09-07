using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeApp.MVCWebPage.Models
{
    public class Currencies
    {

        public List<CurrencyItem> Items { get; set; }

    }

    public class CurrencyItem
    {
        public string Name;
        public CurrencyItem(string _Name)
        {
            this.Name = _Name;
        }
    }
}
