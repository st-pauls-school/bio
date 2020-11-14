using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Unlock.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Assert(Calculate("mnoqRTwxy") == "RST");
            Debug.Assert(Calculate("ABF") == "a");
            Debug.Assert(Calculate("gklmq") == "L");
            Debug.Assert(Calculate("ghkLNQSTwXy") == "LMRSY");
            Debug.Assert(Calculate("ghkLmNrTWXy") == "LMrSY");
            // It's a bit slow from here ... 
            Debug.Assert(Calculate("abrs") == "ACDgHIjMN");
            Debug.Assert(Calculate("deHi") == "DhLNpqrstuvxy");
        }

        static void Setup(IList<int> state, string initial)
        {
            foreach(char c in initial)
            {
                if(c >= 'a')
                {
                    state[c-'a'] = (state[c-'a'] + 1)%3; 
                } else {
                    state[c-'A'] = (state[c-'A'] + 2)%3; 
                }
            }
            
        }

        static string Calculate(string initial)
        {
            IList<int> state = Enumerable.Range(1,25).Select(i => 0).ToList();
            Setup(state, initial);
            Queue<Tuple<string, IList<int>>> queue = new Queue<Tuple<string, IList<int>>>();
            queue.Enqueue(new Tuple<string, IList<int>> (string.Empty, state));

            string result = Traverse(queue); 
            return String.IsNullOrEmpty(result) ? "IMPOSSIBLE" : result;
        }

        static string Traverse(Queue<Tuple<string, IList<int>>> queue)
        {
            while(queue.Count > 0)
            {
                Tuple<string, IList<int>> head = queue.Dequeue();
                char next = head.Item1.Length == 0 ? 'a' : (char)(head.Item1.ToLowerInvariant()[head.Item1.Length-1]+1);
                for(char c = next; c < 'z'; ++c)
                {
                    foreach(bool upper in new List<bool> { true, false})
                    {
                        IList<int> state = head.Item2.Select(s => s).ToList();
                        char toUse = upper ? (char)(c + ('A' - 'a')) : c;
                        PressAButton(state, toUse);
                        string presses = head.Item1 + toUse;
                        if(state.All(s => s == 0))
                            return presses;
                        queue.Enqueue(new Tuple<string, IList<int>>(presses, state));
                    }
                }
            }
            return string.Empty;
        }

        static void PressAButton(IList<int> state, char button)
        {
            int offset;
            int repetitions;
            if(button >= 'a')
            {
                offset = button - 'a';
                repetitions = 1;
            }
            else 
            {
                offset = button - 'A';
                repetitions = 2;
            }
            for(int r = 0; r < repetitions; ++r)
            {
                Toggle(state, offset);
                if(offset > 4)
                    Toggle(state, offset-5);
                if(offset < 20)
                    Toggle(state, offset+5);
                if(offset % 5 > 0)
                    Toggle(state, offset-1);
                if(offset % 5 < 4)
                    Toggle(state, offset+1);           
            }
        }

        static void Toggle(IList<int> state, int light)
        {
            ++state[light];
            state[light] %= 3;
        }

        static void OutputState(IList<int> state)
        {
            Console.WriteLine("=====");
            for(int r = 0; r < 5; ++r)
            {
                for(int c = 0; c < 5; ++c)
                {
                    switch(state[r*5 + c])
                    {
                        case(0):
                            Console.Write(" ");
                            break;
                        case(1):
                            Console.Write('d');
                            break;
                        case(2):
                            Console.Write('B');
                            break;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("=====");
        }
    }
}
