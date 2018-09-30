using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q3logic
{
    public class SerialNumbers
    {
        readonly int _length;

        public SerialNumbers(int length)
        {
            _length = length;
        }

        public int Go(int basis)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(basis);
            IDictionary<int, int> d = new Dictionary<int, int>();
            d.Add(basis, 0);

            while(q.Count >0)
            {
                int next = q.Dequeue();
                int level = d[next];
                var transforms = GenerateNeighbours(next);
                foreach(int t in transforms)
                {
                    if (!d.ContainsKey(t))
                    {
                        d.Add(t, level + 1);
                        q.Enqueue(t);
                    }
                }
            }

            int rv = 0;
            foreach(var kvp in d)
            {
                if (kvp.Value > rv)
                    rv = kvp.Value;
            }
            return rv;
        }

        public IList<int> GenerateNeighbours(int number)
        {
            IList<int> rv = new List<int>();


            for (int i = 0; i < _length - 1; i++)
            {
                var broken = Break(_length, number);

                bool a = false;
                if (i > 0)
                {
                    int m = ((broken[i] - broken[i-1]) * (broken[i-1] - broken[i+1]));
                    a = m > 0;
                }
                bool b = false;
                if (i < (_length - 2))
                {
                    int m = ((broken[i] - broken[i + 2]) * (broken[i + 2] - broken[i + 1]));
                    b = m > 0;
                }
                if (a || b)
                {
                    int t = broken[i];
                    broken[i] = broken[i + 1];
                    broken[i + 1] = t;

                    rv.Add(Recombine(broken));
                }
            }

            rv = rv.Distinct().OrderBy(i => i).ToList();

            return rv;
        }

        public static IList<int> Break(int length, int number)
        {
            IList<int> broken = new List<int>();
            int tally = number;
            for (int i = 0; i < length; i++)
            {
                broken.Add(tally % 10);
                tally = tally / 10;
            }
            return broken.Reverse().ToList();
        }

        public static int Recombine(IList<int> pieces)
        {
            int rv = 0;
            foreach (int i in pieces)
            {
                rv = (rv * 10) + i;
            }
            return rv;

        }
    }
}
