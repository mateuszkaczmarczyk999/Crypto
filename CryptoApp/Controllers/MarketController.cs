using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using CryptoApp.Enums;

namespace CryptoApp.Controllers
{
    public class MarketController : Controller
    {
        // GET: Market
        public ActionResult Index()
        {
            var curencyCollection = Enum.GetValues(typeof(CurrenciesSignatures));
            return View(curencyCollection);
        }
    }
}