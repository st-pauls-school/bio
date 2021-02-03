using System;
using System.Collections.Generic;

namespace WindowDressing.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string a characters, or enter to run the tests");
            string response = Console.ReadLine();
            if(string.IsNullOrEmpty(response))
            {
                foreach(string s in new List<string> {"A", "AB", "BA", 
                    "ACB", // 5
                    "DCBA", // 8
                    "ABCDEFGH", // 8
                    "BACDE", // 6
                    "AEDBC", // 12
                    "BACDEFGH", // 9
                    "CFBGAHDE", // 15
                    
                    "GADEFBC", // 16 ~20ms 
                    "GCFBEDA", // 21 ~800ms
                    "CHDGABFE", // 23 ~4000ms / 4s 
                    "AHGEFDCB", // 27 ~210s
                    
                }) {
                    int t2 = Environment.TickCount;
                    Console.Write($"{s} - {Resolve3(s)} ");
                    int t3 = Environment.TickCount;
                    Console.Write($"3:{t3-t2} ");
                    Console.WriteLine();
                }
            }
            else 
                Console.WriteLine($"{response} - {Resolve3(response)}");

        }

        // Resolve 3 - the third iteration. The first two involved a class holding the current value with the instructions to get there, 
        // the second of these with a cache of those created before. 
        // n.b. a cache of previous runs to be used in subsequent calculations could shave some time off, but is probably not allowed. 
        // that second iteration suggested that while caching the instructions is potentially helpful (e.g. two SS negate each other)
        // it isn't saving *that* much time 
        static int Resolve3(string target){
            if(target == "A") return 1;
            Queue<string> q = new Queue<string>();
            q.Enqueue("A");
            string head;
            IDictionary<string, int> seen = new Dictionary<string, int> {{"A", 1}}; 
            while(q.Count > 0) {
                head = q.Dequeue();

                string a = head + (char)('A' + head.Length);
                int generation = seen[head] + 1;
                if(a == target) 
                    return generation;  
                if(!seen.ContainsKey(a)) {
                    q.Enqueue(a);
                    seen.Add(a, generation);
                }

                if(head.Length >= 2) {
                    string s = head[1].ToString() + head[0].ToString() + head.Substring(2);
                    if(s == target) 
                        return generation;
                    if(!seen.ContainsKey(s)) { 
                        q.Enqueue(s);
                        seen.Add(s, generation);
                    }
                    string r = head.Substring(1) + head[0].ToString();
                    if(r == target) 
                        return generation; 
                    if(!seen.ContainsKey(r)) {
                        q.Enqueue(r);
                        seen.Add(r, generation);
                    }
                }
            }
            return -1;
        }
    }
}
