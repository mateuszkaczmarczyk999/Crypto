using System;

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

        bool SubstractFunds(CurrencySignatures toSell, decimal quantity)
        {
            try
            {
                MyCurrencies[toSell] = Decimal.Substract(MyCurrencies[toSell], quantity);
                return true;
            }
            catch
            {
                return false;
            }

        }


    }
}
