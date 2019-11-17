using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheRightTrack.Lib
{
    public class Track
    {
        IDictionary<char, Point> _points;

        public Track(string flipflops)
        {
            _points = new Dictionary<char, Point>();
            for(char i = 'A'; i <= 'X'; i++)
            {
                _points.Add(i, new Point(i, !(flipflops.Contains(i))));
            }

            foreach (string code in new List<string> {
                "ADEF", "BCGH", "CBIJ", "DAKL", "EAMN", "FANO", "GBOP", "HBPQ", "ICQR", "JCRS", "KDST", "LDTM", 
                "MULE", "NUEF", "OVFG", "PVGH", "QWHI", "RWIJ", "SXJK", "TXKL", "UVMN", "VUOP", "WXQR", "XWST"
                })
                _points[code[0]].InitialSetup(_points[code[1]], _points[code[2]], _points[code[3]], code[0] >= 'M' && code[0] <= 'X');
        }

        public string Journey(char from, char to, int steps)
        {
            if (_points[from].Leaving[1] != to)
                return string.Format("Not going {0}{1} - {2}?", from, to, _points[from].Leaving);
            Point pFrom = _points[from];
            Point pNow = _points[to];
            for(int i = 0; i < steps; i++)
            {
                Point pNext = pNow.EnteringFrom(pFrom);
                pFrom = pNow;
                pNow = pNext;
            }
            return new string(new char[] { pFrom.Name, pNow.Name });
        }

    }
}
