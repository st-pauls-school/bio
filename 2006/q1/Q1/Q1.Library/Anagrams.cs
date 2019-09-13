using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1.Library
{
    public class Anagrams
    {
        public static string Checker(string v1, string v2)
        {
            bool rv = true;

            if (v1.Length != v2.Length)
                rv = false;
            else {
                List<char> l1 = new List<char>(v1);
                List<char> l2 = new List<char>(v2);

                l1.Sort();
                l2.Sort();

                for (int i = 0; i < v1.Length; i++)
                {
                    if (l1[i] != l2[i])
                    {
                        rv = false;
                        break;
                    }
                }
            }
            return string.Format("{0}Anagrams", rv ? "" : "Not ");
        }
    }
}
