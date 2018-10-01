using System;
using System.Text;

namespace q3
{
    public class NewOrder
    {
        public static int NChooseR(UInt64 n, UInt64 r)
        {
            if (n < r)
                return 0;
            if (n == r || n == 0)
                return 1;
            UInt64 rv = 1;
            for (UInt64 i = n; i > (n-r); i--)
                rv *= i;
            for (UInt64 i = 2; i <= r; i++)
                rv /= i;
            return (int)rv;
        }

        public static string NthWithMOnes(int n, int m)
        {            
            // Console.WriteLine("{0} {1}", n, m);
            int counter = 0;
            int digits = m;
            int next = 1;
            while(counter + next < n)
            {
                counter = counter + next;
                digits++;
                next = NChooseR((UInt64)digits-1, (UInt64)m-1); // it's m-1 because we know the first digit must be a one
                // Console.WriteLine("{0}C{1} = {2} => {3}", digits - 1, m - 1, next, counter + next);
            }
            int i;
            // this is still too slow - some 30 seconds for the longest instance. Will need to add in some similar logic as 
            // above - does it start with 11, 111, 1111 etc. 
            for(i = (int)Math.Pow(2, digits-1); counter < n; i++)
            {
                if (HowManyOnes(i) == m) counter++;
                if (counter == n) break;
            }                

            return Encode(i);
        }

        public static string Encode(int i)
        {
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            string bin = Convert.ToString(i, 2);
            while(counter < bin.Length)
            {
                sb.Append(bin[counter]);
                counter++;
                if(counter%6 == 0)
                    sb.Append(' ');
            }
            return sb.ToString().TrimEnd();
        }

        public static int HowManyOnes(int i)
        {
            int rv = 0;
            while(i > 0)
            {
                if ((i & 1) == 1) rv++;
                i >>= 1;
            }
            return rv;
        }
    }
}
