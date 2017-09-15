using System;
using System.Linq;

namespace CryptoRatesProvider
{
    public enum RateProvider { CryptoCompare }
    public class RatesProviderServiceFactory
    {
        private RatePair[] _ratePairs;
        public RatesProviderServiceFactory(params RatePair[] ratePairs)
        {
            _ratePairs = ratePairs;
        }

        public IRatesProvider GerProvider(RateProvider provider)
        {
            switch (provider)
            {
                case RateProvider.CryptoCompare:
                {
                    return CreateCryptocompare();
                }
                default:
                    throw new ArgumentException("Rate provider not implemented");
            }
        }

        private IRatesProvider CreateCryptocompare()
        {
            var subscribeStrings =  _ratePairs
                .Select(pair => $"5~CCCAGG~{pair.From.ToString().ToUpper()}~{pair.To.ToString().ToUpper()}")
                .ToArray();
            var parser = new CryptoCompareDataParser();
            return new CryptoCompareRatesProvider(parser, subscribeStrings);
        }
    }
}