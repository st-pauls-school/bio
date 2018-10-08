using System;
using System.Collections.Generic;
using System.Linq;

namespace q3
{
    public class MovieMagic
    {
        IList<int> _scenes;  

        public MovieMagic(int v, List<int> list)
        {
            _scenes = list;
            if (_scenes.Count != v)
                throw new ArgumentOutOfRangeException("too many scenes given");
        }

        public int Options
        {
            get
            {
                IList<IList<int>> basic = new List<IList<int>>();
                for (int i = 0; i < _scenes.Count; i++)
                    basic.Add(new List<int>());

                return Extend(basic, _scenes);
            }
        }
        
        public static int Extend(IList<IList<int>> incoming, IList<int> counts)
        {
            int total = incoming.Select(x => x.Count).Sum();
            if (total == counts.Sum())
                return 1;
            int next = total + 1;
            int rv = 0;
            for(int i = 0; i < incoming.Count; i++)
            {
                incoming[i].Add(next);
                if(ValidateDecreasing(incoming) && ValidateWithinRange(incoming,counts))
                    rv += Extend(incoming, counts);
                incoming[i].Remove(next);
            }
            return rv;
        }

        public static bool ValidateWithinRange<T>(IList<IList<T>> scenes, IList<int> counts)
        {
            if (scenes.Count != counts.Count)
                return false;
            for (int i = 0; i < scenes.Count; i++)
                if (scenes[i].Count > counts[i])
                    return false;
            return true;
        }
        
        public static bool ValidateDecreasing<T>(IList<IList<T>> scenes)
        {
            int previous = scenes[0].Count;
            foreach(IList<T> l in scenes)
            {
                if (l.Count > previous)
                    return false;
                previous = l.Count;
            }
            return true;            
        }
    }
}
