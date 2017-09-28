using CryptoRatesProvider;
using CryptoRatesProvider.Enums;

namespace CryptoApp.Models
{
    public interface IMarket
    {
        bool Exchange(CurrencySignature toSell, CurrencySignature toBuy, decimal quantity, IWallet wallet);
        void OnRatesUpdated(object source, RatesEventArgs args);
    }
}