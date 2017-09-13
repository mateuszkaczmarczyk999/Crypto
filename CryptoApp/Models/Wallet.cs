using System;
using System.Collections.Generic;

namespace CryptoApp.Models
{

    public class Wallet : IWallet
    {
        public string Id { get; set; }
        private Dictionary<CurrencySignatures, decimal>  MyCurrencies { get; set; }

        public Wallet()
        {
            
        }

        public bool HasEnoughFunds(CurrencySignatures toSell, decimal quantity)
        {          
                if (MyCurrencies[toSell] >= quantity)
                {
                    return true;
            }
            return false;
        }

        public bool SubstractFunds(CurrencySignatures toSell, decimal quantity)
        {
            try
            {
                MyCurrencies[toSell] = Decimal.Subtract(MyCurrencies[toSell], quantity);
                return true;
            }
            catch
            {
                return false;
            }

        }


    }
}
