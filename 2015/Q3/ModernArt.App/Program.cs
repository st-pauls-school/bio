using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ModernArt.App
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1
            IList<int> art = new List<int> { 1,2,1,0};
            Debug.Assert(Orderings(art, 8, 0, Factorials(art.Sum())) == "BCAB");
            //2
            art = new List<int> { 1,0,0,0};
            Debug.Assert(Orderings(art, 1, 0, Factorials(art.Sum())) == "A");
            //3
            art = new List<int> { 1,1,0,0};
            Debug.Assert(Orderings(art, 2, 0, Factorials(art.Sum())) == "BA");
            //4
            art = new List<int> { 0, 3, 0, 3};
            Debug.Assert(Orderings(art, 12, 0, Factorials(art.Sum())) == "DBBDBD");
            //5
            art = new List<int> {5, 5, 0, 0};
            Debug.Assert(Orderings(art, 56, 0, Factorials(art.Sum())) == "AABBBBBAAA");
            //6
            art = new List<int> { 2, 2, 2, 2};
            Debug.Assert(Orderings(art, 2520, 0, Factorials(art.Sum())) == "DDCCBBAA");
            //7
            art = new List<int> { 2, 3, 4, 5};
            Debug.Assert(Orderings(art, 1234567, 0, Factorials(art.Sum())) == "CCBDBDACDADBCD");
            //8
            art = new List<int> { 5, 4, 4, 4};
            Debug.Assert(Orderings(art, 123456789, 0, Factorials(art.Sum())) == "CACBDAABDACBADCBD");
            //9
            art = new List<int> { 5, 5, 5, 5};
            Debug.Assert(Orderings(art, 11223344556, 0, Factorials(art.Sum())) == "DDACBBABCDDDCAABCCBA");
        }

        static IList<ulong> Factorials(int limit)
        {
            IList<ulong> f = new List<ulong> { 1, 1};
            while(f.Count < limit)
            {
                f.Add(f.Last()*(ulong)f.Count);
            }
            return f;
        }

        static string Orderings(IList<int> art, ulong n, int offset, IList<ulong> factorials)
        {
            if(art.Sum() == 0)
                return string.Empty;                
            if(art[offset] == 0)
            {           
                return Orderings(art, n, ++offset, factorials);
            }
            --art[offset];
            ulong nextblock = factorials[art.Sum()]/Product(art, factorials);
            if(n <= nextblock)
            {
                // it starts with the offset 
                return (char)('A'+offset) + Orderings(art, n, 0, factorials);
            }
            ++art[offset];
            return Orderings(art, n-nextblock, ++offset, factorials);
        }

        static ulong Product(IList<int> counts, IList<ulong> factorials)
        {
            ulong p = 1; 
            foreach(int c in counts)
                p *= factorials[c];
            return p;
        }
    }
}
