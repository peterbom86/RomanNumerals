using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    public class RomanNumeralsCalculator
    {
        public ICollection<RomanNumeral> Numerals { get; set; } = new List<RomanNumeral>();

        public RomanNumeralsCalculator()
        {
            // Creation
            var i = new RomanNumeral('I', 1);
            var v = new RomanNumeral('V', 5);
            var x = new RomanNumeral('X', 10);
            var l = new RomanNumeral('L', 50);
            var c = new RomanNumeral('C', 100);
            var d = new RomanNumeral('D', 500);
            var m = new RomanNumeral('M', 1000);

            // Setup of rules
            i.CanPostfix(i);
            i.CanPostfix(v);
            i.CanPostfix(x);            

            v.CanPostfix(x);
            v.CanPostfix(l);
            v.CanPostfix(c);
            v.CanPostfix(d);
            v.CanPostfix(m);
            v.CanBePrefixedWith(i);

            x.CanPostfix(x);
            x.CanPostfix(l);
            x.CanPostfix(c);            
            x.CanBePrefixedWith(i);

            l.CanPostfix(c);
            l.CanPostfix(d);
            l.CanPostfix(m);
            l.CanBePrefixedWith(x);

            c.CanPostfix(c);
            c.CanPostfix(d);
            c.CanPostfix(m);
            c.CanBePrefixedWith(x);            

            d.CanPostfix(m);
            d.CanBePrefixedWith(c);
            
            m.CanBePrefixedWith(c);

            Numerals.Add(i);
            Numerals.Add(v);
            Numerals.Add(x);
            Numerals.Add(l);
            Numerals.Add(c);
            Numerals.Add(d);
            Numerals.Add(m);

            Numerals = Numerals.OrderBy(n => n.NumericValue).ToList();

            var test = new NumeralCollection(null);
        }

        public string Calculate(int v, string result = "")
        {
            if (Numerals.Any(n => n.NumericValue == v))
            {
                result = Numerals.Single(n => n.NumericValue == v).Symbol.ToString();
                return result;
            }

            // Take the first numeral higher than the target number, then check if we get the target number by applying one of the prefix numerals
            // If target number is higher than number, take the highest numeral
            var firstLarger = Numerals.FirstOrDefault(x => x.NumericValue >= v);

            if (firstLarger == null)
            {
                firstLarger = Numerals.First();
            }
            
            var largest = firstLarger.PrefixList.OrderByDescending(x => x.NumericValue).FirstOrDefault();

            if (largest != null && (firstLarger.NumericValue - largest.NumericValue) <= v)
            {
                result += largest.Symbol.ToString() + firstLarger.Symbol.ToString();
                v -= (firstLarger.NumericValue - largest.NumericValue);

                if (v == 0)
                {
                    return result;
                }
                else
                {
                    result = Calculate(v, result);
                }
            }
            else
            {
                var firstLower = Numerals.OrderByDescending(n => n.NumericValue).FirstOrDefault(x => x.NumericValue <= v);
                result += firstLower.Symbol.ToString();

                v -= firstLower.NumericValue;
                if (v == 0)
                {
                    return result;
                }
                                
                result = Calculate(v, result);
            }            

            // if not, take the first numeral lower than the target number, substract the value taken from the target number

            // now, we need to find a new number, recurse and find the target number above + one prefix or the first below the target number

            return result;
        }
    }
}
