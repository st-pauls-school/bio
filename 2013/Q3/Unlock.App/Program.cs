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
            
            // it struggles with the two impossible situations  
            Debug.Assert(Calculate("N") == "IMPOSSIBLE");
            Debug.Assert(Calculate("abcdef") == "IMPOSSIBLE");

            Debug.Assert(Calculate("ABF") == "a");

            // there are many solutions, these assertions contain the first and the shortest 
            Debug.Assert(new List<string> {"L", "ceGHiJklnOqrStuVWxy"}.Contains(Calculate("gklmq")));
            Debug.Assert(new List<string> {"ABcdEFgHIklMnOpQUWY", "LMRSY"}.Contains(Calculate("ghkLNQSTwXy")));
            Debug.Assert(new List<string> {"ABcdEFgHIklMnOpQRUWY", "LMrSY"}.Contains(Calculate("ghkLmNrTWXy")));

            // struggles from here too 
            Debug.Assert(new List<string> {"AbcdEFgIkLMOpRtuvwX","ACDgHIjMN"}.Contains(Calculate("abrs")));
            Debug.Assert(new List<string> {"abCdefGHiKnoQtUvwxy","DhLNpqrstuvxy"}.Contains(Calculate("deHi")));


            Debug.Assert(CalculateWithLists("mnoqRTwxy") == "RST");
            Debug.Assert(CalculateWithLists("ABF") == "a");
            Debug.Assert(CalculateWithLists("gklmq") == "L");
            Debug.Assert(CalculateWithLists("ghkLNQSTwXy") == "LMRSY");
            Debug.Assert(CalculateWithLists("ghkLmNrTWXy") == "LMrSY");
            // It's a bit slow from here ... 
            Debug.Assert(CalculateWithLists("abrs") == "ACDgHIjMN");
            Debug.Assert(CalculateWithLists("deHi") == "DhLNpqrstuvxy");
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
            ulong state = Setup(initial);
            /* using a 64 bit integer with the 2 LSBs representing box A,
             * each subsequent pair representing the next box. 
             * 00 off
             * 01 dim 
             * 10 bright 
             * 11 unused
             */
            // use a stack for a depth first, existence based traversal 
            Stack<Tuple<string, ulong>> stack = new Stack<Tuple<string, ulong>>();
            stack.Push(new Tuple<string, ulong>(string.Empty, state));
            string result = Traverse(stack); 
            return String.IsNullOrEmpty(result) ? "IMPOSSIBLE" : result;


        }

        static ulong Setup(string initial)
        {
            ulong value = 0;
            foreach(char c in initial)
            {
                int offset = 0;
                ulong pattern = 0;
                // lower case is ASCII higher than upper case, so if at least 'a'
                // it's lower, otherwise upper 
                if(c >= 'a')
                {
                    offset = c - 'a';
                    pattern = 0b01;
                } else { 
                    offset = c - 'A';
                    pattern = 0b10;
                }
                ulong mask = pattern << (offset * 2);
                value = value ^ (ulong)mask;
                // OutputState(value);
            }
            return value;
        }

        static string Traverse(Stack<Tuple<string, ulong>> stack)
        {
            while(stack.Count > 0)
            {
                Tuple<string, ulong> head = stack.Pop();
                char next = head.Item1.Length == 0 ? 'a' : (char)(head.Item1.ToLowerInvariant()[head.Item1.Length-1]+1);
                Console.WriteLine("{0} {1} [{2}]", head.Item1, next, stack.Count);
                for(char c = next; c < 'z'; ++c)
                {
                    foreach(bool upper in new List<bool> { true, false})
                    {
                        char toUse = upper ? (char)(c + ('A' - 'a')) : c;
                        ulong state = PressAButton(head.Item2, toUse);
                        string presses = head.Item1 + toUse;
                        if(state == 0)
                            return presses;
                        stack.Push(new Tuple<string, ulong>(presses, state));

                    }
                }
            }
            return string.Empty;
        }

        static ulong PressAButton(ulong state, char button)
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
                state = Toggle(state, offset);
                if(offset > 4)
                    state = Toggle(state, offset-5);
                if(offset < 20)
                    state = Toggle(state, offset+5);
                if(offset % 5 > 0)
                    state = Toggle(state, offset-1);
                if(offset % 5 < 4)
                    state = Toggle(state, offset+1);           
            }
            return state;
        }

        static ulong Toggle(ulong state, int box)
        {
            // set the mask 
            int mask = 0b11;
            // grab the bit pattern for the current box 
            ulong thisbox = (state >> (box * 2)) & (ulong)mask;
            // set the current box to zero 
            state = state ^ (thisbox << (box * 2));
            // increment the thisbox pattern
            thisbox = (thisbox + 1) % 3;
            // set the current state to the new pattern 
            state = state | (thisbox << box * 2);
            return state;
        }

        static void OutputState(ulong state)
        {
            Console.WriteLine("=====");
            for(int r = 0; r < 5; ++r)
            {
                for(int c = 0; c < 5; ++c)
                {
                    ulong pattern = state & 0b11;
                    state = state >> 2;
                    switch(pattern)
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

        static string CalculateWithLists(string initial)
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
