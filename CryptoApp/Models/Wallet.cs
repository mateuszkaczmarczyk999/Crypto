using System.Collections.Generic;
using CryptoApp.Enums;
using CryptoApp.Errors;

namespace CryptoApp.Models
{
    public class Wallet : IWallet
    {
        public string Id { get; set; }
        public Dictionary<CurrenciesSignatures, decimal> MyCurrencies { get; private set; }

        public Wallet()
        {
            foreach (var currencySignature in CurrenciesSignatures)
            {
                MyCurrencies.Add(currencySignature,0);
            }
        }

        public bool HasEnoughFunds(CurrenciesSignatures toSell, decimal quantity)
        {
            return MyCurrencies[toSell] >= quantity;
        }

        public void SubstractFunds(CurrenciesSignatures toSell, decimal quantity)
        {
            if (HasEnoughFunds(toSell, quantity))
                MyCurrencies[toSell] = decimal.Subtract(MyCurrencies[toSell], quantity);
            else
                throw new NotEnoughFundsException();
        }

        public void AddFunds(CurrenciesSignatures toBuy, decimal quantity)
        {
            MyCurrencies[toBuy] = decimal.Add(MyCurrencies[toBuy], quantity);
        }
    }
}