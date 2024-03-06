using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecomeADeveloperTest
{
    internal static class Ext
    {
        public static bool IsNullOrEmpty<T>(this T[] array)
        {
            if (array == null || array.Length == 0)
                return true;
            else
                return array.All(item => item == null);
        }
    }
}
