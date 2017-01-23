namespace RomanNumerals
{
    public class RomanNumeralsCalculator
    {
        private OrderedRomanNumeralCollection NumeralsCollection;

        public RomanNumeralsCalculator()
        {
            NumeralsCollection = new OrderedRomanNumeralCollection();
        }

        public string Calculate(int value)
        {
            var request = new RomanNumeralRequest(value, NumeralsCollection);

            request = request.Calculate(request);
            return request.FinalResult.NumeralSymbols;            
        }
    }
}