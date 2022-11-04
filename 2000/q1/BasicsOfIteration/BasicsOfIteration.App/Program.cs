using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsOfIteration.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimesTableF(12, 12);
            TimesTableW(12, 12);

            //foreach ((int key, int value) p in Enumerate(new List<int> { 1, 2, 3, 4, 5 }))
            //{
            //    Console.WriteLine($"{p.key} {p.value}");
            //}
            Console.ReadKey();
        }

        static void TimesTableF(uint n, uint m)
        {
            int padA = (int)Math.Ceiling(Math.Log10(m));
            int padB = (int)Math.Ceiling(Math.Log10(n * m));
            for (int i = 1; i <= m; ++i)
            {
                string s = string.Format("{0,1}", i, -padA);
                Console.WriteLine($"{s} * {n} = {(i * n)}");
            }
        }
        static void TimesTableW(uint n, uint m)
        {
            int padA = (int)Math.Ceiling(Math.Log10(m));
            int padB = (int)Math.Ceiling(Math.Log10(n * m));
            int i = 1;
            do
            {
                Console.WriteLine($"{i.ToString().PadLeft(padA)} * {n} = {(i * n).ToString().PadLeft(padB)}");
            } while (i++ < m);
        }

        static IEnumerable<(int, T)> Enumerate<T>(List<T> items)
        {
            for(int i = 0; i < items.Count; ++i)
            {
                yield return (i, items[i]);
            }
        }

    }
}
