using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q1
{
    public class isbn
    {
        readonly string _value;
        public isbn(string input)
        {
            _value = input;
        }

        public char Missing
        {
            get
            {
                string candidate = _value.Replace('?', 'X');
                if (IsValid(candidate))
                    return 'X';
                for (char r = '0'; r <= '9'; r++)
                {
                    candidate = _value.Replace('?', r);
                    if (IsValid(candidate))
                        return r ;
                }
                return ' ';
            }
        }

        public static int CheckDigit(string value)
        {
            int total = 0;
            if (value.Length != 10)
                return ' ';
            for(int i = 0; i < 10; i++)
            {
                if (value[i] == '?')
                    continue;
                int charactervalue = value[i] == 'X' ? 10 : Convert.ToInt16(value[i])-(int)'0';
                total += (10 - i) * charactervalue;
            }
            int check = 11 - (total % 11);
            return check == 11 ? 0 : check;
        }

        public static bool IsValid(string value)
        {
            return CheckDigit(value) == 0;
        }
    }
}
