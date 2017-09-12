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

        bool HasEnoughFunds(CurrencySignatures toSell, decimal quantity)
        {
            
                if (MyCurrencies[toSell] >= toSell)
                {
                    return true;
                }
            return false;
        }

        
    }
}
