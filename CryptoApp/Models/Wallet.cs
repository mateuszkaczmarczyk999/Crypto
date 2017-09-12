using System;
using System.Linq;

namespace CryptoApp.Models
{

    public class Wallet : IWallet
    {
        public string Id { get; set; }
        public Dictionary<CurrencySignatures, decimal>  MyCurrencies { get; set; }

        public Wallet()
        {
            
        }

        bool IsEnoughFunds(CurrencySignatures toSell, decimal quantity)
        {
            if (MyCurrencies.TryGetValue(toSell, out decimal actual))
            {
                if (actual >= toSell)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
