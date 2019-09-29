using System.Collections.Generic;

namespace Q3
{
    class Change
    {
        readonly uint _value;
        readonly uint _level;
        public uint Value => _value;
        public uint Level => _level;
        public Change(uint value, uint level = 0){
            _value = value;
            _level = level;
        }

        public override string ToString() 
        {
            return string.Format("{0}/{1}", Value, Level);
        }

        public IList<Change> Generate()
        {
            IList<Change> rv = new List<Change>();
            rv.Add(new Change(Operation1(_value), _level+1));
            rv.Add(new Change(Operation2(_value), _level+1));
            rv.Add(new Change(Operation3(_value), _level+1));
            rv.Add(new Change(Operation4(_value), _level+1));

            return rv;
        }


        public static uint Operation1(uint val)
        {
            uint back = val%1000; // last 3 digits 
            uint leading = val/1000000; // leading digit 
            uint front = (val/1000) % 1000;  // last 3 of the first 4 
            return front * 10000 + leading * 1000 + back;
        }

        public static uint Operation2(uint val)
        {
            uint trailing = val%10; // last digit 
            uint next = (val%10000) /10;  // the next 3  
            uint front = val/10000; // front 3 
            return front * 10000 + trailing * 1000 + next;
        }

        public static uint Operation3(uint val)
        {
            uint middle = (val/1000)%10;
            uint left = val/10000;
            uint right = val%1000;
            return middle *1000000 + left * 1000 + right;
        }

        public static uint Operation4(uint val)
        {
            uint middle = (val/1000)%10;
            uint left = val/10000;
            uint right = val%1000;
            return left * 10000 + right * 10 + middle;
        }

    }
}
