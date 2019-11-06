using System;
using System.Collections.Generic;
using System.Linq;

namespace q1
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong a = 123456789;
            IList<int> res = AnagramNumbers.Generate(a);
            if(res.Count == 0)
                Console.WriteLine("No");
            else 
                Console.WriteLine(res.Aggregate((a,b) => a + ' ' + b));

        }
    }
}
