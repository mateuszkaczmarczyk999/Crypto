using System.Collections.Generic;
using CryptoApp.Errors;

namespace CryptoApp.Models
{
    public class Wallet : IWallet
    {
        public string Id { get; set; }
        public Dictionary<CurrencySignatures, decimal> MyCurrencies { get; private set; }

        public Wallet()
        {
            foreach (var currencySignature in CurrencySignatures)
            {
                MyCurrencies.Add(currencySignature,0);
            }
        }

        public bool HasEnoughFunds(CurrencySignatures toSell, decimal quantity)
        {
            return MyCurrencies[toSell] >= quantity;
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