using System.Diagnostics;
using CryptoApp.Hubs;
using CryptoRatesProvider;
using CryptoRatesProvider.Enums;

namespace CryptoApp
{
    public class RatesProviderConfig
    {
        public static void RegisterProvider()
        {
            var providerFactory = new RatesProviderServiceFactory(
                new RatePair(CurrencySignature.Btc, CurrencySignature.Eur),
                new RatePair(CurrencySignature.Eth, CurrencySignature.Eur),
                new RatePair(CurrencySignature.Ltc, CurrencySignature.Eur),
                new RatePair(CurrencySignature.Eth, CurrencySignature.Btc),
                new RatePair(CurrencySignature.Eth, CurrencySignature.Ltc),
                new RatePair(CurrencySignature.Btc, CurrencySignature.Ltc));

            var provider = providerFactory.GerProvider(RateProvider.CryptoCompare);
            provider.RatesUpdated += (sender, eventArgs) => TestMarket.GetInstance().OnRatesUpdated(sender, eventArgs);
            provider.StartService();

            //            provider.RatesUpdated += (sender, eventArgs) =>
            //            {
            //                Debug.WriteLine(
            //                    $"from {eventArgs.ChangeFrom} to {eventArgs.ChangeTo} {eventArgs.PriceAction} {eventArgs.Value}"
            //                );
            //            };
        }
    }
}