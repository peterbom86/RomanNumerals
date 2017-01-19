using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    public class RomanNumeral
    {
        public char Symbol { get; private set; }
        public int NumericValue { get; private set; }

        public List<RomanNumeral> PrefixList { get; private set; }
        public List<RomanNumeral> PostFixList { get; private set; }

        public RomanNumeral(char symbol, int numericValue)
        {
            this.Symbol = symbol;
            this.NumericValue = numericValue;
            this.PrefixList = new List<RomanNumeral>();
            this.PostFixList = new List<RomanNumeral>();
        }

        public void CanBePrefixedWith(RomanNumeral numeral)
        {
            PrefixList.Add(numeral);
        }

        public void CanPostfix(RomanNumeral numeral)
        {
            PostFixList.Add(numeral);
        }
    }
}
