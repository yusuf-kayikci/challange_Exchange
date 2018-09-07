using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExchangeApp.MVCWebPage.Models;
using Microsoft.AspNetCore.Http;

namespace ExchangeApp.MVCWebPage.Controllers
{
    public class HomeController : Controller
    {
        public static List<CurrencyItem> item = new List<CurrencyItem>();
        public IActionResult Index()
        {
            item.Add(new CurrencyItem("TÜRK LİRASI"));
            item.Add(new CurrencyItem("ABD DOLARI"));
            item.Add(new CurrencyItem("AVUSTRALYA DOLARI"));
            item.Add(new CurrencyItem("DANİMARKA KRONU"));
            item.Add(new CurrencyItem("EURO"));
            item.Add(new CurrencyItem("İNGİLİZ STERLİNİ"));
            item.Add(new CurrencyItem("İSVİÇRE FRANGI"));
            item.Add(new CurrencyItem("İSVEÇ KRONU"));
            item.Add(new CurrencyItem("KANADA DOLARI"));
            item.Add(new CurrencyItem("KUVEYT DİNARI"));
            item.Add(new CurrencyItem("NORVEÇ KRONU"));
            item.Add(new CurrencyItem("İSVİÇRE FRANGI"));
            item.Add(new CurrencyItem("İSVEÇ KRONU"));
            item.Add(new CurrencyItem("SUUDİ ARABİSTAN RİYALİ"));
            item.Add(new CurrencyItem("JAPON YENİ"));
            item.Add(new CurrencyItem("BULGAR LEVASI"));
            item.Add(new CurrencyItem("RUMEN LEYİ"));
            item.Add(new CurrencyItem("RUS RUBLESİ"));
            item.Add(new CurrencyItem("İRAN RİYALİ"));
            item.Add(new CurrencyItem("ÇİN YUANI"));
            item.Add(new CurrencyItem("PAKİSTAN RUPİSİ"));
            item.Add(new CurrencyItem("KATAR RİYALİ"));
            item.Add(new CurrencyItem("BULGAR LEVASI"));

            ApiCaller apicaller = new ApiCaller();
            return View("Index" , apicaller.getCurrencyName());
        }


        [HttpPost]
        public IActionResult Calc(string fromCurrency,string toCurrency , int amount)
        {
            Calculator calculator = new Calculator(fromCurrency, toCurrency, amount);
            double result = calculator.Calculate();
            ViewBag.resultText = Math.Round(result,2);
            ViewBag.Cur1 = fromCurrency;
            ViewBag.Cur2 = toCurrency;
            ViewBag.amount = amount;
            return Index();
        }
    }
}