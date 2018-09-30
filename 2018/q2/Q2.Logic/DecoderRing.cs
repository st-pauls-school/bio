using System.Collections.Generic;
using System.Text;

namespace Q2.Logic
{
    public class DecoderRing
    {
        readonly int _offset;
        string _ring;
        readonly bool _shift;

        public DecoderRing(int offset, bool shift=true)
        {
            _offset = offset;
            _shift = shift;
            _ring = CalculateRing();
        }

        public string FirstSix {  get { return _ring.Substring(0, 6); } }

        public string Encode(string value)
        {
            StringBuilder encoded = new StringBuilder();
            foreach (char c in value)
                encoded.Append(Encode(c));
            return encoded.ToString();
        }

        public int Cycle(string value)
        {
            int steps = 0;
            string encoded = value;
            do
            {
                encoded = Encode(encoded);
                steps++;
            }
            while (steps < 100000 && encoded != value);
            return encoded == value ? steps : -1;
        }

        public void Reset()
        {
            _ring = CalculateRing();
        }

        public char Encode(char value)
        {
            int offset = value - 'A';
            char rv = _ring[offset];
            if(_shift)
                Shift();
            return rv;
        }

        string CalculateRing()
        {
            IList<char> ring = new List<char>();
            for(char c = 'A'; c <= 'Z'; c++)
            {
                ring.Add(c);
            }
            int i = -1;
            StringBuilder sb = new StringBuilder();
            while(ring.Count > 0)
            {
                i = (i + _offset) % ring.Count;
                sb.Append(ring[i]);
                ring.RemoveAt(i);
                i--;
            }
            return sb.ToString();
        }

        void Shift()
        {
            _ring = _ring.Substring(1, 25) + _ring[0];
        }

        public static int Cycler(string value)
        {
            int max = 0;
            for (int i = 1; i <= 10000; i++)
            {
                int cy = new DecoderRing(i, false).Cycle(value.ToUpperInvariant());
                if (cy > max)
                    max = cy;
            }
            return max;
        }
    }
}
