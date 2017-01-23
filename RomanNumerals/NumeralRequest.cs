using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    public class NumeralRequest
    {
        public int RemainingValue { get; set; }
        public string TempResult { get; set; }

        public NumeralRequest(int value)
        {
            RemainingValue = value;
            TempResult = string.Empty;
        }

        public NumeralRequest AddNumeral(RomanNumeral numeral)
        {
            TempResult += numeral.Symbol.ToString();
            RemainingValue -= numeral.NumericValue;

            return this;
        }

        public NumeralRequest AddNumeralWithPrefix(RomanNumeral numeral)
        {
            TempResult += numeral.GreatestPrefix().Symbol.ToString() + numeral.Symbol.ToString();
            RemainingValue -= (numeral.NumericValue - numeral.GreatestPrefix().NumericValue);

            return this;
        }

        public bool ResultFound()
        {
            return RemainingValue == 0;
        }

        /// <summary>
        /// This might be overkill.. :)
        /// </summary>        
        public NumeralRequest CheckForResultFound(NumeralRequest request, Func<NumeralRequest, NumeralRequest> action)
        {
            if (request.ResultFound())
            {
                return request;
            }
            else
            {
                request = action.Invoke(this);                         
                return request;
            }
        }        
    }
}
