using System;
using System.Collections.Generic;
using System.Linq;

namespace Q1.App
{
    class Program
    {
        static void Main(string[] args)
        {
            // from the question paper 
            Console.WriteLine(5 == EenieMeenie(6,4));
            Console.WriteLine(4 == EenieMeenie(7,3));

            // from the mark scheme 
            Console.WriteLine(5 == EenieMeenie(6, 4));
            Console.WriteLine(40 == EenieMeenie(40, 1)); 
            Console.WriteLine(1 == EenieMeenie(20, 8));
            Console.WriteLine(27 == EenieMeenie(37, 19));
            Console.WriteLine(149 == EenieMeenie(200, 200));
            Console.WriteLine(230 == EenieMeenie(230, 173));
            Console.WriteLine(31 == EenieMeenie(555, 444));
            Console.WriteLine(9 == EenieMeenie(999, 82));
            Console.WriteLine(49 == EenieMeenie(82, 999));
        }

        public static int EenieMeenie(int friends, int words)
        {
            // https://stackoverflow.com/questions/4926362/easier-way-to-populate-a-list-with-integers-in-net
            IList<int> players = Enumerable.Range(1, friends).ToList();
            int pointer = 0;
            while(players.Count > 1)
            {
                // add the number of words, but deduct 1 to account for the person removed i.e. if we'd previously removed person 3, 
                // the person in 3 needs to be counted in the next move 
                pointer = (pointer + words -1 ) % players.Count;  
                players.RemoveAt(pointer);
                
            }
            return players[0];
        }
    }
}
