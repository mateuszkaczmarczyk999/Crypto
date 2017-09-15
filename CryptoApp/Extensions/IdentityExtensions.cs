
namespace CryptoApp.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetOrganizationId(this System.Security.Principal.IIdentity identity)
        {
            var claim = ((System.Security.Claims.ClaimsIdentity)identity).FindFirst("WalletId");

            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}