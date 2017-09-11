using System;
using System.Collections.Generic;

namespace CryptoApp.Models
{
    public class Market
    {
        private static readonly Lazy<Market> _instance =
            new Lazy<Market>(() => new Market());

        public Dictionary<RatesSignatures, decimal> Rates { get; set; }

        public static Market GetInstance()
        {
            return _instance.Value;
        }

        public enum CurrenciesSignatures
        {
            Eur,
            Eth,
            Btc,
            Ltc
        }

        public enum RatesSignatures
        {
            EurEth,
            EurBtc,
            EurLtc,
            EthEur,
            BtcEur,
            LtcEur,
            EthBtc,
            EthLtc,
            BtcEth,
            BtcLtc,
            LtcEth,
            LtcBtc
        }
    }