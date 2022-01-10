using System;
using Migration.Lib;
using System.Collections.Generic;


namespace Migration.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid g = new Grid(3, new List<int> { 2,3,5,7,11,13}, 999);
            g.Go(true);
            Console.WriteLine("Solution8:");
            Console.WriteLine(g.State());
        }
    }
}
