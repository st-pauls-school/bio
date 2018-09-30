using System;
using System.Collections.Generic;
using System.Linq;

namespace q3
{
    public class IncreasingPasswords
    {
        const int limit = 1000000000;
        readonly IList<int> _limits;

        readonly int _symbolCount;

        public IList<int> Limits {  get { return _limits; } }

        public IncreasingPasswords(int cSymbols)
        {
            _symbolCount = cSymbols;
            _limits = GenerateLimits();
        }

        public int NChooseK(int n, int k)
        {
            int result = 1;
            for (int i = 1; i <= k; i++)
            {
                result *= n - (k - i);
                result /= i;
            }
            return result;
        }

        IList<int> GenerateLimits()
        {
            IList<int> limits = new List<int>();
            int previous = 0;
            for(int i = 1; i<= _symbolCount; i++)
            {
                if (previous > limit)
                    break;
                int next = NChooseK(_symbolCount, i) + previous;
                
                limits.Add(next);
                previous = next;

            }


            return limits;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
