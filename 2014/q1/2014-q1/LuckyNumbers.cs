using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIO2014_Q1
{
    public class LuckyNumbers
    {
        readonly IList<int> _candidates;

        public LuckyNumbers(int cap)
        {
            _candidates = Generate(cap);
        }

        IList<int> Generate(int cap)
        {
            IList<int> candidates = new List<int>();
            for (int i = 1; i < cap; i += 2)
                candidates.Add(i);
            int luckyindex = 1;

            while (luckyindex < candidates.Count)
            {
                int step = candidates[luckyindex];
                int i = step - 1;
                while (i < candidates.Count)
                {
                    candidates[i] = 0;
                    i += step;
                }
                candidates = candidates.Where(c => c != 0).ToList();

                luckyindex += 1;
            }

            return candidates;
        }

        public int Lower(int value)
        {
            return _candidates.Where(c => c < value).LastOrDefault();
        }

        public int Higher(int value)
        {
            return _candidates.Where(c => c > value).FirstOrDefault();
        }

        public int Below(int value)
        {
            return _candidates.Where(c => c < value).Count();
        }

    }
}


