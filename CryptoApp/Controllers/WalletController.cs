using CryptoApp.Models;
using CryptoApp.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace CryptoApp.Controllers
{
    [Authorize]
    public class WalletController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WalletController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Wallet
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var wallet = _context.Users.SingleOrDefault(u => u.Id == userId)?.UserWallet;
            return View(wallet);
        }

        public ActionResult Exchange()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Exchange(ExchangeFundsViewModel model)
        {
            var market = Market.GetInstance();
            var userId = User.Identity.GetUserId();
            var wallet = _context.Users.SingleOrDefault(u => u.Id == userId)?.UserWallet;

            market.Exchange(model.ToSell, model.ToBuy, model.Quantity, wallet);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}