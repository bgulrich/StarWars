using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.UniversalWindows.Converters
{
    public static class RomanNumeralConverter
    {
        public static string IntToRomanNumeral(int value)
        {
            var rn = new RomanNumerals.RomanNumeral(value);
            return rn.ToString();
        }

    }
}
