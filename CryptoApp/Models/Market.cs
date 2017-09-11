using System;

namespace CryptoApp.Models
{
    public class Market
    {
        private static readonly Lazy<Market> _instance =
            new Lazy<Market>(() => new Market());
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