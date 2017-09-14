using System;
using System.Collections.Generic;
using System.Linq;
using CryptoApp.Enums;
using CryptoApp.Errors;

namespace CryptoApp.Models
{
    public class Wallet : IWallet
    {
        public Wallet()
        {
            MyCurrencies = new Dictionary<CurrenciesSignatures, decimal>();
            foreach (var currencySignature in Enum.GetValues(typeof(CurrenciesSignatures)).Cast<CurrenciesSignatures>())
                MyCurrencies.Add(currencySignature, 0);
        }

        public string Id { get; set; }
        public Dictionary<CurrenciesSignatures, decimal> MyCurrencies { get; }

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