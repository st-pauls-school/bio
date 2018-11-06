using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q3.Logic
{
    public class ChildsPlay
    {
        readonly Arrangements _arrangements;

        public ChildsPlay(Arrangements a)
        {
            if (a == null)
                a = new Arrangements(32);
            _arrangements = a;
        }

        public IList<int> Result(int s, int n)
        {
            IList<int> blocks = new List<int>();
            while(s > 0)
            {
                int total = 0;
                for(int block = 1; block <= 9; block++)
                {
                    int after = _arrangements.Blocks(s)[block-1];
                    if (total + after >= n)
                    {
                        blocks.Add(block);
                        n -= total;
                        s -= block;
                        break;
                    }
                    total += after;
                }
            }
            return blocks;
        }
    }
}
