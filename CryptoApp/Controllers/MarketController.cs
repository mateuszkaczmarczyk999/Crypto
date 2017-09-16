using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CryptoApp.Enums;
using CryptoApp.Hubs;
using CryptoApp.Models;

namespace CryptoApp.Controllers
{
    public class MarketController : Controller
    {
        // GET: Market
        public ActionResult Index()
        {
            var curencyCollection = Enum.GetValues(typeof(CurrenciesSignatures));
            var newTask = Task.Run(() => TestMarket.GetInstance().OnRatesUpdated(new object(), new CurrenciesRatesEvantArgs()));
            return View(curencyCollection);
        }
    }
}