using System.Diagnostics;
using CryptoRatesProvider;
using CryptoRatesProvider.Enums;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CryptoApp.Startup))]
namespace CryptoApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var providerFactory = new RatesProviderServiceFactory(
                new RatePair(CurrencySignature.Btc, CurrencySignature.Eur),
                new RatePair(CurrencySignature.Eth, CurrencySignature.Eur),
                new RatePair(CurrencySignature.Ltc, CurrencySignature.Eur),
                new RatePair(CurrencySignature.Eth, CurrencySignature.Btc),
                new RatePair(CurrencySignature.Eth, CurrencySignature.Ltc),
                new RatePair(CurrencySignature.Btc, CurrencySignature.Ltc));

            var provider = providerFactory.GerProvider(RateProvider.CryptoCompare);
            provider.RatesUpdated += (sender, eventArgs) =>
            {
                Debug.WriteLine(
                    $"from {eventArgs.ChangeFrom} to {eventArgs.ChangeTo} {eventArgs.PriceAction} {eventArgs.Value}"
                );
            };
            provider.StartService();
        }
    }
}
