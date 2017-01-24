using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    public interface IOrderedRomanNumeralsCollection
    {
        RomanNumeral GetLowest();
        RomanNumeral GetNumeralMatching(int remainingValue);
        bool LargestNumeralIsLessThanOrEqualTo(int value);
        bool ValueMatchesANumeral(int value);
        RomanNumeral GetGreatest();
        RomanNumeral FindLowestGreaterThanOrEqualTo(int remainingValue);
        RomanNumeral GetGreatestLowerThanOrEqualTo(int remainingValue);
    }
}
