using CryptoApp.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace CryptoApp.Controllers
{
    public class WalletController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WalletController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Wallet
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var wallet = _context.Users.SingleOrDefault(u => u.Id == userId)?.UserWallet;
            return View(wallet);
        }
    }
}