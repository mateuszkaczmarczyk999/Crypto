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
            MyFunds = new List<Currency>();
            foreach (var currencySignature in Enum.GetValues(typeof(CurrenciesSignatures)).Cast<CurrenciesSignatures>())
                MyFunds.Add(new Currency{CurrencySignature = currencySignature, Value = 0});
        }

        public string Id { get; set; }
        public List<Currency> MyFunds { get; }

        public bool HasEnoughFunds(CurrenciesSignatures toSell, decimal quantity)
        {
            return MyFunds[toSell] >= quantity;
        }

        public void SubstractFunds(CurrenciesSignatures toSell, decimal quantity)
        {
            if (HasEnoughFunds(toSell, quantity))
                MyFunds[toSell] = decimal.Subtract(MyFunds[toSell], quantity);
            else
                throw new NotEnoughFundsException();
        }

        public void AddFunds(CurrenciesSignatures toBuy, decimal quantity)
        {
            MyFunds[toBuy] = decimal.Add(MyFunds[toBuy], quantity);
        }
    }
}