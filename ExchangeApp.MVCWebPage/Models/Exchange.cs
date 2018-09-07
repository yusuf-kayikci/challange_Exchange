using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeApp.MVCWebPage.Models
{
    public class Exchange
    {
        public List<ExchangeItem> items; 
    }

    public class ExchangeItem
    {
        public string CurrencyName { get; set; }
        public double ForexBuying { get; set; }
        public double ForexSelling { get; set; }

        public ExchangeItem(string _currencyName , double _forexBuying , double _forexSelling)
        {
            this.CurrencyName = _currencyName;
            this.ForexBuying = _forexBuying;
            this.ForexSelling = _forexSelling;
        }
    }
}
