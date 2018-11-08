using System;

namespace q3.Logic
{
    public class UpsideDown
    {
        readonly ulong _number;
        public UpsideDown(int n)
        {
            _number = (ulong)n;
        }

        public ulong Value
        {
            get
            {
                if (_number == 1)
                    return 5;
                ulong counter = 1;
                int digits = 2;
                while (true)
                {
                    int firsthalflength = digits / 2;
                    ulong after = counter + (ulong)Math.Pow(9, firsthalflength);
                    if (after >= _number)
                    {

                        return Construct(Offset(_number - counter, firsthalflength), digits % 2 == 1);
                    }
                    digits++;
                    counter = after;
                }
            }
        }

        public static ulong Offset(ulong count, int digits)
        {
            if (digits == 1)
                return count;

            count--;
            ulong tens = 1;
            ulong value = 0;
            while(digits > 0)
            {
                value += ((count % 9) + 1 ) * tens;
                tens *= 10;
                count /= 9;
                digits--;
            }
            return value;
        }

        public static ulong Construct(ulong firstHalf, bool five)
        {
            ulong value = five ? 5u : 0;
            ulong n = firstHalf;
            if (five)
                firstHalf *= 10;
            while (n > 0)
            {
                firstHalf *= 10;
                value *= 10;
                value += (10 - n % 10);
                n /= 10;
            }
            return value + firstHalf;
        }
    }
}
