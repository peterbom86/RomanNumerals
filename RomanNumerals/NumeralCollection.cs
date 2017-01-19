using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    public class NumeralCollection
    {
        private ICollection<RomanNumeral> Numerals { get; set; }

        public NumeralCollection(IList<RomanNumeral> numerals)
        {
            if (numerals == null)
            {
                throw new ArgumentNullException();
            }

            if (numerals.Count < 1)
            {
                throw new ArgumentOutOfRangeException("At least one numeral must be included", new ArgumentOutOfRangeException());
            }

            Numerals = numerals.OrderByDescending(n => n.NumericValue).ToList();
        }

        public RomanNumeral GetHighestNumeral()
        {
            return Numerals.First();
        }
    }
}
