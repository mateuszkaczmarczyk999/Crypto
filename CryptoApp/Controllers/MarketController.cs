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
            var curencyCollection = Enum.GetValues(typeof(CurrencySignature));
            return View(curencyCollection);
        }
    }
}