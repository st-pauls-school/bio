using System.Collections.Generic;
using System.Linq;

namespace q1
{
    public static class AnagramNumbers
    {

        public static IList<int> Generate(ulong a)
        {
            IList<int> rv = new List<int>();
            for(ulong g = 2; g < 10; g++)
                if(Compare(a, g*a))
                    rv.Add((int)g);
            return rv;
        }

        public static bool Compare(ulong a, ulong b)
        {
            List<char> l1 = new List<char>(a.ToString());
            List<char> l2 = new List<char>(b.ToString());
            l1.Sort();
            l2.Sort();
            return l1.SequenceEqual(l2);
        }
    }
}