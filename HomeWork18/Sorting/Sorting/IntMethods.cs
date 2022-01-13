using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    internal static class IntMethods
    {
        public static int CustomComparator(int a, int b)
        {
            if (a - b > 0) return 1;
            if (a - b < 0) return -1;
            return 0;
        }
        // predicate to get even numbers
        public static bool CustomPredicate(int i) => i % 2 == 0;
    }
}
