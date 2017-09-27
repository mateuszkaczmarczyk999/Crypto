using System;
using System.Collections.Generic;
using System.Linq;
using CryptoRatesProvider.Enums;
using CryptoApp.Errors;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoApp.Models
{
    public class Wallet : IWallet
    {
        public Wallet(bool isRegistered)
        {
            MyFunds = new List<Currency>();
            foreach (var currencySignature in Enum.GetValues(typeof(CurrencySignature)).Cast<CurrencySignature>())
                MyFunds.Add(new Currency{CurrencySignature = currencySignature, Value = 0.0m});
        }

        public Wallet()
        {
          
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual List<Currency> MyFunds { get; set; }

        public bool HasEnoughFunds(CurrencySignature toSell, decimal quantity)
        {
            return MyFunds.Find(x => x.CurrencySignature==toSell).Value >= quantity;
        }

        public void SubstractFunds(CurrencySignature toSell, decimal quantity)
        {
            if (HasEnoughFunds(toSell, quantity))
                MyFunds.Find(x => x.CurrencySignature == toSell).Value -= quantity;
            else
                throw new NotEnoughFundsException();
        }

        public void AddFunds(CurrencySignature toBuy, decimal quantity)
        {
            MyFunds.Find(x => x.CurrencySignature == toBuy).Value += quantity;
        }
    }
}