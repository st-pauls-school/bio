using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q3.Logic
{
    public class Arrangements
    {
        IList<IList<int>> _arrangements;

        public Arrangements(int limit)
        {
            _arrangements = new List<IList<int>>();
            _arrangements.Add(new List<int>());
            _arrangements.Add(new List<int> { 1 });
            Ensure(limit);
        }

        void Ensure(int limit)
        {
            for(int s = _arrangements.Count; s <= limit; s++)
            {
                IList<int> next = new List<int>();
                for(int block = 1; block <=9; block++)
                {
                    if (s == block)
                    {
                        next.Add(1);
                        break;
                    }
                    else
                        next.Add(_arrangements[s - block].Sum());
                }
                _arrangements.Add(next);
            }
        }

        public IList<int> Blocks(int s)
        {
            return _arrangements[s];
        }

        public IList<int> Counts
        {
            get
            {
                IList<int> rv = new List<int>();
                foreach (IList<int> l in _arrangements)
                    rv.Add(l.Sum());
                return rv;
            }
        }
    }
}
