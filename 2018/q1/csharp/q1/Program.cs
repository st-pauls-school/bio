using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using q1logic;

namespace q1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CAH");
            Console.WriteLine("SPS");
            string input = Console.ReadLine();
            if(input.ToLowerInvariant() == "partb")
            {
                Console.WriteLine(new InterestRepayment(43, 46).Steps);
            } else if (input.ToLowerInvariant() == "partc")
            {
                decimal max = 0m;
                int maxi = 0;
                int maxr = 0;
                for (int i = 0; i <= 100; i++)
                {
                    for (int r = 0; r <= 100; r++)
                    {
                        decimal rp = new InterestRepayment(i, r).TotalRepayment;
                        if (rp > max)
                        {
                            max = rp;
                            maxi = i;
                            maxr = r;
                        }
                    }
                }
                Console.WriteLine("{0} {1}", maxi, maxr);
            }
            else
            {
                IList<string> numbers = input.Split(' ');
                Console.WriteLine(new InterestRepayment(int.Parse(numbers[0]), int.Parse(numbers[1])).TotalRepayment);
            }
            Console.ReadKey();
        }
    }
}
