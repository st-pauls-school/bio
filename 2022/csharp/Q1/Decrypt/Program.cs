using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Decrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindOriginal("ESVNMCW"));
            Debug.Assert(FindOriginal("ESVNMCW") == "ENCRYPT");
            Console.WriteLine(PartC());
            Console.WriteLine(PartB());

        }

        static string FindOriginal(string s)
        {
            IList<int> transformed = s.Select(c => c - 'A').ToList();
            IList<int> original = new List<int> { transformed[0] };
            for (int i = 1; i < transformed.Count; ++i)
                original.Add((26 + transformed[i] - transformed[i - 1] - 1) % 26);
            return string.Join("", original.Select(i => (char)('A' + i)));
        }

        static string PartB()
        {
            string s = "AAAAA";
            while(true)
            {
                string e = Encrypt(s);
                if (e == s)
                    return e;
                s = Next(s);
            }
        }

        static string Next(string s)
        {
            IList<int> transformed = s.Select(c => c - 'A').ToList();
            int pointer = 4;
            while (pointer >= 0)
            {
                if (transformed[pointer] < 25)
                {
                    ++transformed[pointer];
                    pointer = 0;
                }
                else
                {
                    transformed[pointer] = 0;
                }
                --pointer;
            }
            return string.Join("", transformed.Select(i => (char)('A' + i)));
        }

        static int PartC()
        {
            string word = "OLYMPIAD";
            int count = 0;
            do { 
                word = Encrypt(word);
                ++count;
            } while(word != "OLYMPIAD");
            return count;
        }

        static string Encrypt(string s)
        {
            IList<int> transformed = s.Select(c => c - 'A').ToList();
            for (int i = 1; i < transformed.Count; ++i) {
                transformed[i] += transformed[i - 1] + 1;
                transformed[i] %= 26;
            }
            return string.Join("", transformed.Select(i => (char)('A' + i)));

        }


    }
}
