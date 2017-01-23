using System;

namespace RomanNumerals
{
    public class RomanNumeralRequest
    {
        public int RemainingValue { get; set; }
        public Result FinalResult { get; private set; }
        private OrderedRomanNumeralCollection NumeralsCollection;

        public RomanNumeralRequest(int value, OrderedRomanNumeralCollection numeralsCollection)
        {
            RemainingValue = value;
            FinalResult = new Result();
            NumeralsCollection = numeralsCollection;
        }

        public RomanNumeralRequest Calculate(RomanNumeralRequest request)
        {
            if (ValueMatchesANumeralIn(NumeralsCollection))
            {
                AddNumeral(NumeralsCollection.GetNumeralMatching(RemainingValue));

                return this;
            }

            // If target number is higher than the highest numeral, take the highest numeral
            // else
            //  Take the first numeral higher than the target number, then check if we get the target number by applying one of the prefix numerals

            if (NumeralsCollection.ValueIsGreaterThanOrEqualToLargestNumeral(request.RemainingValue))
            {
                request = AddNumeral(NumeralsCollection.GetGreatest());
                request = CheckForResultFoundPossiblyContinueCalculation(this, r => this.Calculate(r));
            }
            else
            {
                // Find the first numeral which is larger then the target number
                var lowestGreaterThanValue = NumeralsCollection.FindLowestGreaterThanOrEqualTo(request.RemainingValue);

                if (NumeralAndPrefixAreLessThanOrEqualToValue(lowestGreaterThanValue))
                {
                    request = AddNumeralWithPrefix(lowestGreaterThanValue);
                    request = CheckForResultFoundPossiblyContinueCalculation(request, r => Calculate(r));
                }
                else // Numeral with the greatest prefix is still greater than the target value, we need to find a numeral lower than the one just above the target number
                {
                    var firstLower = NumeralsCollection.GetGreatestLowerThanOrEqualTo(request.RemainingValue);

                    request = AddNumeral(firstLower);
                    request = CheckForResultFoundPossiblyContinueCalculation(request, r => Calculate(r));
                }
            }

            return request;
        }

        private RomanNumeralRequest AddNumeral(RomanNumeral numeral)
        {
            FinalResult.NumeralSymbols += numeral.Symbol.ToString();
            RemainingValue -= numeral.NumericValue;

            return this;
        }

        private bool ValueMatchesANumeralIn(OrderedRomanNumeralCollection numeralsCollection)
        {
            return numeralsCollection.ValueMatchesANumeral(RemainingValue);
        }

        private RomanNumeralRequest AddNumeralWithPrefix(RomanNumeral numeral)
        {
            FinalResult.NumeralSymbols += numeral.GreatestPrefix().Symbol.ToString() + numeral.Symbol.ToString();
            RemainingValue -= (numeral.NumericValue - numeral.GreatestPrefix().NumericValue);

            return this;
        }

        private bool ResultFound()
        {
            return RemainingValue == 0;
        }

        private RomanNumeralRequest CheckForResultFoundPossiblyContinueCalculation(RomanNumeralRequest request, Func<RomanNumeralRequest, RomanNumeralRequest> calculationMethod)
        {
            if (request.ResultFound())
            {
                return request;
            }
            else
            {
                request = calculationMethod.Invoke(this);
                return request;
            }
        }

        private bool NumeralAndPrefixAreLessThanOrEqualToValue(RomanNumeral numeral)
        {
            return numeral.NumericValue - numeral.GreatestPrefix().NumericValue <= RemainingValue;
        }

        public class Result
        {
            public string NumeralSymbols { get; set; }
        }        
    }
}