using System.Diagnostics;

namespace BlockPalindrome.App
{
    class Program
    {
        static void Main(string[] args)
        {
            // given examples 
            Debug.Assert(Calculate("BONBON") == 1);
            Debug.Assert(Calculate("ONION") == 1);
            Debug.Assert(Calculate("BBACBB") == 3);

            // mark scheme 
            Debug.Assert(Calculate("XX") == 1);
            Debug.Assert(Calculate("YZ") == 0);
            Debug.Assert(Calculate("OLYMPIAD") == 0);
            Debug.Assert(Calculate("RACECAR") == 3);
            Debug.Assert(Calculate("KKKKKKK") == 7);
            Debug.Assert(Calculate("BBIIOIIBB") == 9);
            Debug.Assert(Calculate("PPPQQQQPPP") == 19);
            Debug.Assert(Calculate("AAAAAAAAAA") == 31);

            /*
            Console.Write("input 2-10 characters: ");            
            Console.WriteLine(Calculate(Console.ReadLine()));
            */
        }

        static int Calculate(string value)
        {
            int total = 0;
            for(int i = 0; i < value.Length / 2; ++i) 
            {
                if(value.Substring(0,i+1) == value.Substring(value.Length-(i+1), i+1))
                    total += 1 + Calculate(value.Substring(i+1, value.Length-2*(i+1)));
            }
            return total;
        }         
    }
}
