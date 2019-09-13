using System;
using System.Collections.Generic;
using System.Linq;

namespace q3
{
    public class Program
    {
        static int Factorial(int i)
        {
            if (i <= 1)
                return 1;
            return i * Factorial(i - 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("{0}", Calculator(7, 3) == 6);
            Console.WriteLine("{0}", Calculator( 33, 1) == 0);
            Console.WriteLine("{0}", Calculator( 101, 4) == 0);
            Console.WriteLine("{0}", Calculator( 8, 7) == 1);
            Console.WriteLine("{0}", Calculator( 28, 1) == 1);
            Console.WriteLine("{0}", Calculator( 18, 2) == 8);
            Console.WriteLine("{0}", Calculator( 9, 4) == 22);
            Console.WriteLine("{0}", Calculator( 36, 3) == 191);
            Console.WriteLine("{0}", Calculator( 33, 4) == 2075);
            Console.WriteLine("{0}", Calculator( 83, 5) == 40000);
            Console.WriteLine("{0}", Calculator( 73, 6) == 1402584);
            Console.WriteLine("{0}", Calculator( 95, 8) == 515725220);
        }
        public static int Calculator(int target, int cDrats) 
        {
            IList<IList<int>> candidates = new List<IList<int>>();
            int lengthCounter = 1;
            const int Segments = 20;
            for(int i = 1; i <= ((target/2 < Segments ) ? target/2  : Segments); i++)
            {
                candidates.Add(new List<int>{i});
            }

            while(lengthCounter < cDrats)
            {
                var interim = new List<IList<int>>();
                foreach(var item in candidates)
                {
                    if((item.Sum() + item[0] + cDrats - item.Count) > target)
                        continue;
                    if(item.Sum() + item[0] + (cDrats - item.Count)*Segments < target)
                        continue;

                    for(int n = (item.Count == 1 ? 1 : item.Last()); n <= Segments; n++)
                    {
                        if(item.Sum() + item[0] + n > target)
                            break;
                        IList<int> candidate = item.Select(i => i).ToList();
                        candidate.Add(n);
                        interim.Add(candidate);
                    }

                }

                candidates = interim.Select(i => i).ToList(); // careful - aliasing 
                if(candidates.Count == 0)
                    break;
                lengthCounter = candidates[0].Count;
            }

            var alternates = new List<IList<int>>();
            foreach(var item in candidates)
            {
                if(item.Sum() + item[0] == target)
                    alternates.Add(item.Select(i => i).ToList());

            }

            int itemCounter = 0;
            int numerator = Factorial(cDrats-1);
            foreach(var item in alternates)
            {
                int denominator = 1;
                int current = 1; 
                // we look at the previous item, but start at 2 because we're ignoring the first double counter 
                for(int i = 2; i < item.Count; i++)
                {
                    current = (item[i] == item[i-1] ? current + 1 : 1);
                    denominator *= current;                    
                }
                
                int contribution = numerator / denominator;
                // Console.WriteLine("{0}-{1}: [{2}]", itemCounter, itemCounter + contribution - 1, string.Join(", ", item.Select(i => i.ToString())));
                itemCounter += contribution;

            }

            Console.WriteLine("Solutions: {0}", itemCounter);

            return(itemCounter);
        }
    }
    
}
