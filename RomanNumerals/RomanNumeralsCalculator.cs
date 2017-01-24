namespace RomanNumerals
{
    public class RomanNumeralsCalculator
    {
        private IOrderedRomanNumeralsCollection NumeralsCollection;

        public RomanNumeralsCalculator()
        {
            // Todo: inject this so that we can (possibly) change it for another implementation.
            NumeralsCollection = new OrderedRomanNumeralsCollection();
        }

        public string Calculate(int value)
        {
            var request = new RomanNumeralRequest(value, NumeralsCollection);
            request = request.Calculate();
            return request.FinalResult.NumeralSymbols;            
        }
    }
}