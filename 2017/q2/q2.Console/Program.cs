using q2.Logic;
using System;
using System.Collections.Generic;

namespace q2.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> vals = new List<int>();
            for (int i = 0; i <= 4; i++)
                vals.Add(Convert.ToInt32(args[i]));
                

            Grid g = new Grid(vals[0], vals[1], vals[2], vals[3]);
            bool successful = false;
            for(int i = 0; i < vals[4]; i++)
            {
                successful = g.Move(!successful);
            }
            System.Console.WriteLine(g);
        }
    }
}
