using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    public static class Extenders
    {
        public static int ToInt(this string a, int defaultValue = 0)
        {
            if (int.TryParse(a, out var result))
            {
                return result;
            }
            return defaultValue;
        }

        public static int ToInt(this Fraction f)
        {
            return f.Number;
        }
    }
}
