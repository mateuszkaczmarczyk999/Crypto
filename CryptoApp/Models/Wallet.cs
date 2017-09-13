using System.Collections.Generic;
using CryptoApp.Errors;

namespace CryptoApp.Models
{
    public class Wallet : IWallet
    {
        public string Id { get; set; }
        private Dictionary<CurrencySignatures, decimal> MyCurrencies { get; set; }

        public bool HasEnoughFunds(CurrencySignatures toSell, decimal quantity)
        {
            if (MyCurrencies[toSell] >= quantity)
                return true;
            return false;
        }

        public void SubstractFunds(CurrencySignatures toSell, decimal quantity)
        {
            if (HasEnoughFunds(toSell, quantity))
                MyCurrencies[toSell] = decimal.Subtract(MyCurrencies[toSell], quantity);
            else
                throw new NotEnoughFundsException();
        }

        public void AddFunds(CurrencySignatures toBuy, decimal quantity)
        {
            MyCurrencies[toBuy] = decimal.Add(MyCurrencies[toBuy], quantity);
        }
    }
}