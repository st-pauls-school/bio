using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1.Lib
{
    public class AnagramNumbers
    {
        public static List<int> Generate(ulong value)
        {
            List<int> rv = new List<int>();
            for (ulong g = 2; g < 10; g++)
                if (Compare(value, g * value))
                    rv.Add((int)g);
            return rv;
        }
        public static bool Compare(ulong a, ulong b)
        {
            List<int> la = a.ToString().Select(c => (int)c).ToList();
            List<int> lb = b.ToString().Select(c => (int)c).ToList();
            la.Sort();
            lb.Sort();
            return la.SequenceEqual(lb);
        }
    }
}
