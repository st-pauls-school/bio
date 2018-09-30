using Q3Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();
            IQuestion3 q3 = new Question3();
            int p = 2;
            int i = 3;
            int n = 4;
            int w = 3;
            Console.WriteLine(q3.Run(p, i, n, w));

            Console.Read();
        }
    }
}
