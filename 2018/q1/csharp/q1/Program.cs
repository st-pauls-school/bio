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
                IList<ValueTuple<int, int, decimal>> maxima = new List<ValueTuple<int, int, decimal>>();
                for (int i = 0; i <= 100; i++)
                {
                    for (int r = 0; r <= 100; r++)
                    {
                        decimal rp = new InterestRepayment(i, r).TotalRepayment;
                        if (rp == max)
                            maxima.Add((i, r, max));
                        if (rp > max)
                        {
                            max = rp;
                            maxima.Clear();
                            maxima.Add((i, r, max));
                        }
                    }
                }
                foreach(ValueTuple<int, int, decimal> tuple in maxima)
                    Console.WriteLine($"({tuple.Item1},{tuple.Item2}) => {tuple.Item3}");
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
