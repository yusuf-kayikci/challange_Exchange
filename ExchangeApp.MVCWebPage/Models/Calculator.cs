using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeApp.MVCWebPage.Models
{
    public class Calculator
    {
        

        public string fromCurrency { set; get; }
        public string toCurrency { set; get; }
        public double amount { set; get; }
        public ApiCaller apicaller { set; get; }

        public Calculator(string _fromCurrency , string _toCurrency,int _amount)
        {
            this.fromCurrency = _fromCurrency;
            this.toCurrency = _toCurrency;
            this.amount = _amount;
            this.apicaller = new ApiCaller();
        }

        public double Calculate()
        {
            Exchange exchanges = new Exchange();
            exchanges.items = this.apicaller.GetExchanges();
            ExchangeItem Cur1 = exchanges.items.Where(item => item.CurrencyName == this.fromCurrency).First();
            ExchangeItem Cur2 = exchanges.items.Where(item => item.CurrencyName == this.toCurrency).First();
 
            double rate = (Cur1.ForexBuying / Cur2.ForexBuying);
            double result = rate * amount;
            return result;
        }
    }
}
