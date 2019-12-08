using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoderRing.Lib
{
    public class Ring
    {
        readonly string _mapping;
        public string FirstSix 
        { 
            get 
            { 
                return _mapping.Substring(0, 6); 
            } 
        }
                
        public Ring(int n)
        {
            _mapping = string.Empty;

            StringBuilder sb = new StringBuilder();
            List<char> letters = Enumerable.Range('A', 26).Select(i => (char)i).ToList();
            int index = 0;
            while(letters.Count > 0)
            {
                index += n-1;
                index %= letters.Count;
                sb.Append(letters[index]);
                letters.RemoveAt(index);
            }
            _mapping = sb.ToString();
        }

        public string Encode(string word)
        {
            int offset = 0;
            StringBuilder sb = new StringBuilder();
            foreach(char c in word)
            {
                sb.Append(_mapping[(c - 'A' + offset)%26]);
                offset = (offset+1)% 26;                
            }
            return sb.ToString();
        }
    }
}
