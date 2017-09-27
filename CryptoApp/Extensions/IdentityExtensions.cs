
namespace CryptoApp.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetWalletId(this System.Security.Principal.IIdentity identity)
        {
            var claim = ((System.Security.Claims.ClaimsIdentity)identity).FindFirst("UserWallet_Id");

            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}