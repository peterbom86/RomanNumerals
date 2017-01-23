using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RomanNumerals
{
    public class OrderedNumeralCollection
    {
        private IOrderedEnumerable<RomanNumeral> _numerals;

        /// <summary>
        /// Returns an ascending ordered list of roman numerals
        /// </summary>
        public IEnumerable<RomanNumeral> Items
        {
            get
            {
                return _numerals.AsEnumerable();
            }
        }

        public OrderedNumeralCollection()
        {
            _numerals = CreateNumerals()
                .OrderBy(n => n.NumericValue);
        }

        public RomanNumeral GetLowest()
        {
            return Items.First();
        }

        public RomanNumeral GetNumeralMatching(int remainingValue)
        {
            return _numerals.Single(n => n.NumericValue == remainingValue);
        }

        public bool ValueIsGreaterThanOrEqualToLargestNumeral(int value)
        {
            return value >= _numerals.Last().NumericValue;
        }

        public bool ValueMatchesANumeral(int value)
        {
            return _numerals.Any(n => n.NumericValue == value);            
        }

        public RomanNumeral GetGreatest()
        {
            return _numerals.Last();
        }

        private ICollection<RomanNumeral> CreateNumerals()
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
            v.CanBePrefixedWith(i);
            x.CanBePrefixedWith(i);

            l.CanBePrefixedWith(x);
            c.CanBePrefixedWith(x);

            d.CanBePrefixedWith(c);
            m.CanBePrefixedWith(c);

            var numeralList = new Collection<RomanNumeral>();
            numeralList.Add(i);
            numeralList.Add(v);
            numeralList.Add(x);
            numeralList.Add(l);
            numeralList.Add(c);
            numeralList.Add(d);
            numeralList.Add(m);

            return numeralList;
        }

        public RomanNumeral FindLowestGreaterThanOrEqualTo(int remainingValue)
        {
            if (remainingValue < 1)
            {
                throw new ArgumentOutOfRangeException("Remaining value must be 1 or greater");
            }

            return _numerals.First(x => x.NumericValue >= remainingValue);
        }

        public RomanNumeral GetGreatestLowerThanOrEqualTo(int remainingValue)
        {
            if (remainingValue < 1)
            {
                throw new ArgumentOutOfRangeException("Remaining value must be 1 or greater");
            }

            return _numerals.OrderByDescending(n => n.NumericValue).First(x => x.NumericValue <= remainingValue);
        }
    }
}