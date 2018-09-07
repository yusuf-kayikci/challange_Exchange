using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace ExchangeApp.MVCWebPage.Models
{
    public class ApiCaller
    {
        public XmlDocument xmlDoc;
        public Exchange exchange;
        public Currencies currencies;

        public ApiCaller()
        {
            xmlDoc = new XmlDocument();
        }



        public string getXmlData()
        {

            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                //get tcmb web page xml source
                string XmlData = client.DownloadString(ApiUrl.EXCHANGE_RATE_URL);
                return XmlData;

            }
        }

        public List<CurrencyItem> getCurrencyName()
        {
            try
            {
                currencies = new Currencies();
                string XmlData = getXmlData();
                xmlDoc.LoadXml(XmlData);
                XmlNodeList parentNode = xmlDoc.GetElementsByTagName("Currency");
                currencies.Items = new List<CurrencyItem>();
                currencies.Items.Add(new CurrencyItem("TÜRK LİRASI"));//default value must be.because all values calculated to turkish money in tcmb
                foreach (XmlNode childrenNode in parentNode)
                {
                    string CurrencyName = childrenNode.SelectSingleNode("Isim").InnerText;
                    currencies.Items.Add(new CurrencyItem(CurrencyName));
                }
                return currencies.Items;
            }
            catch(Exception ex)
            {
                throw ex;
            }


        }


        public List<ExchangeItem> GetExchanges()
        {
            exchange = new Exchange();
            var currentCulture = System.Globalization.CultureInfo.InstalledUICulture;
            var numberFormat = (System.Globalization.NumberFormatInfo)currentCulture.NumberFormat.Clone();
            numberFormat.NumberDecimalSeparator = ".";
            //get tcmb web page xml source
            try
            {

                string XmlData = getXmlData();
                xmlDoc.LoadXml(XmlData);
                XmlNodeList parentNode = xmlDoc.GetElementsByTagName("Currency");
                exchange.items = new List<ExchangeItem>();
                exchange.items.Add(new ExchangeItem("TÜRK LİRASI", 1, 1));//default value must be.because all values calculated to turkish money in tcmb
                foreach (XmlNode childrenNode in parentNode)
                {
                    //exchangeItem.CurrencyCode = childrenNode.SelectSingleNode("Currency//CurrencyCode").InnerText;
                    //exchangeItem.ID = Convert.ToInt32(childrenNode.SelectSingleNode("//CrossOrder").InnerText);
                    string CurrencyName = childrenNode.SelectSingleNode("Isim").InnerText;
                    double ForexBuying = (childrenNode.SelectSingleNode("ForexBuying").InnerText == "") ? 0 : double.Parse(childrenNode.SelectSingleNode("ForexBuying").InnerText, numberFormat);
                    double ForexSelling = (childrenNode.SelectSingleNode("ForexSelling").InnerText == "") ? 0 : double.Parse(childrenNode.SelectSingleNode("ForexSelling").InnerText, numberFormat);
                    exchange.items.Add(new ExchangeItem(CurrencyName, ForexBuying, ForexSelling));
                }
                return exchange.items;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
