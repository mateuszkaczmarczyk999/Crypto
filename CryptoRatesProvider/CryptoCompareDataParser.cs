using System;
using System.Globalization;
using CryptoRatesProvider.Enums;

namespace CryptoRatesProvider
{
    public class CryptoCompareDataParser
    {
        private const char DataSeparator = '~';
        private const int MessageTypeIdx = 0;
        private const int PriceActionFlagStrIdx = 17;
        private const int LoadCompleteFlag = '3';
        private const char PriceUnchangedFlag = '4';
        private const int FromCurrencyIdx = 2;
        private const int ToCurrencyIdx = 3;
        private const int RateValueIdx = 5;
        private Func<string, RatesEventArgs> _parseData;

        public CryptoCompareDataParser()
        {
            _parseData = ParseDataBeforeLoadComplete;
        }

        public RatesEventArgs ParseData(string data)
        {
            return _parseData(data);
        }

        private RatesEventArgs ParseDataBeforeLoadComplete(string data)
        {
            if (data[MessageTypeIdx] == LoadCompleteFlag)
            {
                _parseData = ParseDataAfterLoadComplete;
                return null;
            }
            return EventArgsFromData(data);
        }

        private RatesEventArgs ParseDataAfterLoadComplete(string data)
        {
            return data.Length > PriceActionFlagStrIdx && data[PriceActionFlagStrIdx] == PriceUnchangedFlag ? null : EventArgsFromData(data);
        }

        private RatesEventArgs EventArgsFromData(string data)
        {
            var priceActionFlag = data[PriceActionFlagStrIdx];
            var dataArray = data.Split(DataSeparator);
            var priceAction = (PriceAction) char.GetNumericValue(priceActionFlag);
            var fromCurrency = GetCurrencySignature(dataArray[FromCurrencyIdx]);
            var toCurrency = GetCurrencySignature(dataArray[ToCurrencyIdx]);
            var value = decimal.Parse(dataArray[RateValueIdx], CultureInfo.InvariantCulture);
            return new RatesEventArgs{ChangeFrom = fromCurrency, ChangeTo = toCurrency, PriceAction = priceAction, Value = value};
        }

        private CurrencySignature GetCurrencySignature(string currencyString)
        {
            try
            {
                return (CurrencySignature) Enum.Parse(typeof(CurrencySignature), currencyString, true);
            }
            catch (ArgumentException e)
            {
                throw new CurrencyNotImplementedException($"{currencyString} is not implemented!", e);
            }
        }

    }
}