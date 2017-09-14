using CryptoApp.Enums;

namespace CryptoApp.Models
{
    public interface IMarket
    {
        bool Exchange(CurrenciesSignatures toSell, CurrenciesSignatures toBuy, decimal quantity, IWallet wallet);
        void OnRatesUpdated(object source, CurrenciesRatesEvantArgs args);
    }
}