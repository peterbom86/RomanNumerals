using System;

namespace RomanNumerals
{
    public class RomanNumeralRequest
    {
        public int RemainingValue { get; set; }
        public Result FinalResult { get; private set; }
        private IOrderedRomanNumeralsCollection NumeralsCollection;

        public RomanNumeralRequest(int value, IOrderedRomanNumeralsCollection numeralsCollection)
        {
            RemainingValue = value;
            FinalResult = new Result();
            NumeralsCollection = numeralsCollection;
        }

        /// <summary>
        /// Calculates a roman numeral from an arabic.
        /// </summary>
        public RomanNumeralRequest Calculate()
        {
            // Check if the target value matches a numeral.
            if (ValueMatchesANumeralIn(NumeralsCollection))
            {
                AddNumeral(NumeralsCollection.GetNumeralMatching(RemainingValue));
            }
            else
            {
                // If the target value is higher than the highest numeral, take the highest numeral.
                if (NumeralsCollection.LargestNumeralIsLessThanOrEqualTo(RemainingValue))
                {
                    AddNumeral(NumeralsCollection.GetGreatest());
                    CheckForResultFoundPossiblyContinueCalculation(r => Calculate());
                }
                else
                {
                    // Else find the lowest numeral which is still larger then the target number.
                    var lowestGreaterThanNumeral = NumeralsCollection.FindLowestGreaterThanOrEqualTo(RemainingValue);

                    // Check if the previously found numeral - the largest prefix is still less than or equal to the target value, if not, our previous numeral is too large.
                    if (NumeralAndPrefixAreLessThanOrEqualToValue(lowestGreaterThanNumeral))
                    {
                        // If it is lower than the target number, we need to add this and find the remainder.
                        AddNumeralWithPrefix(lowestGreaterThanNumeral);
                        CheckForResultFoundPossiblyContinueCalculation(r => Calculate());
                    }
                    else // The numeral just above the target number, even with the greatest prefix, is still greater than the target value, we need to find the numeral just below the target number and add to it instead.
                    {
                        var highestLowerThanNumeral = NumeralsCollection.GetGreatestLowerThanOrEqualTo(RemainingValue);

                        // Add this and continue evaluation.
                        AddNumeral(highestLowerThanNumeral);
                        CheckForResultFoundPossiblyContinueCalculation(r => Calculate());
                    }
                }
            }

            return this;
        }

        /// <summary>
        /// Adds the numeral to the result and substracts its value from the remaining value.
        /// </summary>        
        private void AddNumeral(RomanNumeral numeral)
        {
            FinalResult.NumeralSymbols += numeral.Symbol.ToString();
            RemainingValue -= numeral.NumericValue;
        }

        /// <summary>
        /// Checks if the values matches a numeral in the provided list of numerals.
        /// </summary>        
        private bool ValueMatchesANumeralIn(IOrderedRomanNumeralsCollection numeralsCollection)
        {
            return numeralsCollection.ValueMatchesANumeral(RemainingValue);
        }

        /// <summary>
        /// Adds the numeral + prefix to the result and substracts the resulting value from the remaining value.
        /// </summary>        
        private void AddNumeralWithPrefix(RomanNumeral numeral)
        {
            FinalResult.NumeralSymbols += numeral.GreatestPrefix().Symbol.ToString() + numeral.Symbol.ToString();
            RemainingValue -= (numeral.NumericValue - numeral.GreatestPrefix().NumericValue);
        }

        /// <summary>
        /// Returns if a result is found, ie. remainder is zero.
        /// </summary>        
        private bool ResultFound()
        {
            return RemainingValue == 0;
        }

        /// <summary>
        /// Checks if a result is found and continues evaluation if a remainder still exists.
        /// </summary>        
        private void CheckForResultFoundPossiblyContinueCalculation(Func<RomanNumeralRequest, RomanNumeralRequest> calculationMethod)
        {
            if (!ResultFound())
            {
                calculationMethod.Invoke(this);
            }
        }

        /// <summary>
        /// Returns if the calculated value from a numeral - prefix are less than or equal to the value of the provided numeral
        /// </summary>        
        private bool NumeralAndPrefixAreLessThanOrEqualToValue(RomanNumeral numeral)
        {
            return numeral.NumericValue - numeral.GreatestPrefix().NumericValue <= RemainingValue;
        }

        /// <summary>
        /// Data structure for keeping the result
        /// </summary>
        public class Result
        {
            public string NumeralSymbols { get; set; }
        }
    }
}