using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USQLCSharpDemo
{
    public static class TypeConverter
    {
        public static decimal ParseToDecimal(string input)
        {
            input = input.Replace(" ", "");
            return decimal.Parse(input, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public static double ParseToDouble(string input)
        {
            input = input.Replace(" ", "");
            return double.Parse(input, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public static int ParseToInt(string input)
        {
            input = input.Replace(" ", "");
            return int.Parse(input);
        }

        public static DateTime ParseToDateTime(string input)
        {
            return DateTime.Parse(input);
        }
    }
}
