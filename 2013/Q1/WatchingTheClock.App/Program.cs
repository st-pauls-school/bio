using System;
using System.Diagnostics;

namespace WatchingTheClock.App
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Debug.Assert(FirstMatch(1,31) == "00:48");
            Debug.Assert(FirstMatch(0, 0) == "01:00");
            Debug.Assert(FirstMatch(18, 18) == "01:18");
            Debug.Assert(FirstMatch(67, 1507) == "02:07");
            Debug.Assert(FirstMatch(0, 15) == "00:00");
            Debug.Assert(FirstMatch(0, 7) == "00:00");
            Debug.Assert(FirstMatch(17, 26) == "13:20");
            Debug.Assert(FirstMatch(17, 215) == "06:40");
            Debug.Assert(FirstMatch(5779, 5864) == "19:12");
            Debug.Assert(FirstMatch(21923, 26268) == "14:24");
        }

        static string FirstMatch(int offset1, int offset2)
        {
            offset1 += 60; 
            offset2 += 60;
            int time1 = offset1 % 1440;
            int time2 = offset2 % 1440;
            while(time1 != time2)
            {
                time1 = (time1 + offset1) % 1440;
                time2 = (time2 + offset2) % 1440;
            }
            return String.Format("{0}:{1}", (time1 / 60).ToString("D2"), (time1 % 60).ToString("D2"));
        }
    }
}
