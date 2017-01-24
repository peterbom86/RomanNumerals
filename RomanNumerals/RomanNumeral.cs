using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals
{
    public class RomanNumeral
    {
        public char Symbol { get; private set; }
        public int NumericValue { get; private set; }

        private static RomanNumeral NullNumeral = new RomanNumeral('-', 0);

        public ICollection<RomanNumeral> PrefixList { get; private set; }

        public RomanNumeral(char symbol, int numericValue)
        {
            this.Symbol = symbol;
            this.NumericValue = numericValue;
            this.PrefixList = new List<RomanNumeral>();

            // Adding a null object to avoid null checks in code
            PrefixList.Add(NullNumeral);
        }

        public void CanBePrefixedWith(RomanNumeral numeral)
        {
            PrefixList.Add(numeral);
        }

        public RomanNumeral GreatestPrefix()
        {
            return PrefixList.OrderByDescending(x => x.NumericValue).First();
        }
    }
}