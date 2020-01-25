using AlphaComplex.Lib;
using System;
using System.Collections.Generic;

namespace AlphaComplex.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Q2b, Q2c, Q2d or the \"letter number number\" for Q1a: ");
            string input = Console.ReadLine();
            switch(input)
            {
                case "Q2b":
                    Console.WriteLine("Q2b: A and AAAA");
                    break;
                case "Q2c":
                case "Q2d":
                    Console.WriteLine("dunno");
                    break;
                default:
                    IList<string> items = input.Split(' ');
                    Plan p = new Plan(items[0]);
                    foreach (string c in p.Connections)
                        Console.WriteLine(c);
                    Console.Write(p.Moves(Convert.ToInt32(items[1])));
                    Console.WriteLine(p.Moves(Convert.ToInt32(items[2])));
                    break;
            }
            Console.ReadKey();
        }
    }
}
