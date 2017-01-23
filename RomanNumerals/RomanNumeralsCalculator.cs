namespace RomanNumerals
{
    public class RomanNumeralsCalculator
    {
        private OrderedNumeralCollection NumeralsCollection;

        public RomanNumeralsCalculator()
        {
            NumeralsCollection = new OrderedNumeralCollection();
        }

        public string Calculate(int value)
        {
            var request = new NumeralRequest(value);
            return Calculate(request).TempResult;
        }

        private NumeralRequest Calculate(NumeralRequest request)
        {
            if (NumeralsCollection.ValueMatchesANumeral(request.RemainingValue))
            {
                request.AddNumeral(NumeralsCollection.GetNumeralMatching(request.RemainingValue));

                return request;
            }

            // If target number is higher than the highest numeral, take the highest numeral
            // else
            //  Take the first numeral higher than the target number, then check if we get the target number by applying one of the prefix numerals

            if (NumeralsCollection.ValueIsGreaterThanOrEqualToLargestNumeral(request.RemainingValue))
            {
                request = request.AddNumeral(NumeralsCollection.GetGreatest());

                if (request.RemainingValue == 0)
                {
                    return request;
                }
                else
                {
                    request = Calculate(request);
                }
            }
            else
            {
                // Find the first numeral which is larger then the target number
                var lowestGreaterThanValue = NumeralsCollection.FindLowestGreaterThanOrEqualTo(request.RemainingValue);

                var greatestPrefix = lowestGreaterThanValue.GreatestPrefix();

                if (NumeralAndPrefixAreLessThanOrEqualToValue(lowestGreaterThanValue, request.RemainingValue))
                {
                    request = request.AddNumeralWithPrefix(lowestGreaterThanValue);

                    request = request.CheckForResultFound(request, r => Calculate(r));
                }
                else // Numeral with the greatest prefix is still greater than the target value, we need to find a numeral lower than the one just above the target number
                {
                    var firstLower = NumeralsCollection.GetGreatestLowerThanOrEqualTo(request.RemainingValue);

                    request = request.AddNumeral(firstLower);

                    request = request.CheckForResultFound(request, r => Calculate(r));
                }
            }

            return request;
        }        

        //private NumeralRequest CheckForResultFound(NumeralRequest request)
        //{
        //    if (request.ResultFound())
        //    {
        //        return request;
        //    }
        //    else
        //    {
        //        request = Calculate(request);
        //        return request;
        //    }
        //}

        private bool NumeralAndPrefixAreLessThanOrEqualToValue(RomanNumeral numeral, int remainingValue)
        {
            return numeral.NumericValue - numeral.GreatestPrefix().NumericValue <= remainingValue;
        }
    }
}