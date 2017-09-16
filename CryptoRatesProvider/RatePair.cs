using CryptoRatesProvider.Enums;

namespace CryptoRatesProvider
{
    public struct RatePair
    {
        public CurrencySignature From { get; }
        public CurrencySignature To { get; }

        public RatePair(CurrencySignature from, CurrencySignature to)
        {
            From = from;
            To = to;
        }
    }
}