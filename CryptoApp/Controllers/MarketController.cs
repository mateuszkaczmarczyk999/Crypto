using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CryptoApp.Hubs;
using CryptoApp.Models;
using CryptoRatesProvider;
using CryptoRatesProvider.Enums;

namespace CryptoApp.Controllers
{
    public class MarketController : Controller
    {
        // GET: Market
        public ActionResult Index()
        {
            var providerFactory = new RatesProviderServiceFactory(
                new RatePair(CurrencySignature.Btc, CurrencySignature.Eur),
                new RatePair(CurrencySignature.Eth, CurrencySignature.Eur),
                new RatePair(CurrencySignature.Ltc, CurrencySignature.Eur),
                new RatePair(CurrencySignature.Eth, CurrencySignature.Btc),
                new RatePair(CurrencySignature.Eth, CurrencySignature.Ltc),
                new RatePair(CurrencySignature.Btc, CurrencySignature.Ltc));

            var provider = providerFactory.GerProvider(RateProvider.CryptoCompare);
            provider.RatesUpdated += (sender, eventArgs) =>
            {
                Debug.WriteLine(
                    $"from {eventArgs.ChangeFrom} to {eventArgs.ChangeTo} {eventArgs.PriceAction} {eventArgs.Value}"
                );
            };
            provider.RatesUpdated += (sender, eventArgs) => TestMarket.GetInstance().OnRatesUpdated(sender, eventArgs);
            provider.StartService();
            var curencyCollection = Enum.GetValues(typeof(CurrencySignature));
            return View(curencyCollection);
        }
    }
}