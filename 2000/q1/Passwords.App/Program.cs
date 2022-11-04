using System.Diagnostics;

Debug.Assert(!Checker("APPLE"));
Debug.Assert(!Checker("CUCUMBER"));
Debug.Assert(Checker("ONION"));
Debug.Assert(Checker("APRICOT"));



static bool Checker(string s)
{
    int sublength = 1;
    while(sublength <= s.Length/2)
    {
        for(int i = 0; i + sublength + sublength < s.Length; ++i)
        {
            if (s.Substring(i, sublength) == s.Substring(i + sublength, sublength))
                return false;
        }
        sublength++;
    }
    return true;

}