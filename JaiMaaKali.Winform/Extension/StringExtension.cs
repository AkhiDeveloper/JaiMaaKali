using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Extension
{
    public static class StringExtensions
    {
        public static int GetStartingNumber(this string input)
        {
            var result = 0;
            var foundNumber = false;
            var numberStarted = false;
            foreach (var c in input)
            {
                if (char.IsDigit(c))
                {
                    if (!numberStarted)
                    {
                        numberStarted = true;
                    }
                    result = result * 10 + (c - '0');
                    foundNumber = true;
                }
                else
                {
                    if (numberStarted)
                    {
                        break;
                    }
                }
            }
            if (!foundNumber)
            {
                return 0;
                //throw new ArgumentException("No number found in string");
            }
            return result;
        }
    }

}
