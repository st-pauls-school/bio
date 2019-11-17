using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheRightTrack.Lib
{
    public class Point : IEquatable<Point>
    {
        Point _l;
        Point _t;
        Point _b;

        readonly bool _isLazy;
        readonly char _name;

        public Point L => _l;
        public Point T => _t;
        public Point B => _b;

        Point _next;

        public char Name => _name;

        public Point(char name, bool isLazy)
        {
            _name = name;
            _isLazy = isLazy;
        }

        public void InitialSetup(Point l, Point t, Point b, bool leftIsT)
        {
            _l = l;
            _t = t;
            _b = b;
            _next = _t;
        }

        public Point EnteringFrom(Point from)
        {
            if(_isLazy)
            {
                if (from == _l)
                    return _next;
                _next = from;
                return _l;
            }

            if (from == _t || from == _b)
                return _l;
            Point rv = _next == _t ? _t : _b;
            _next = _next == _t ? _b : _t;
            return rv;

        }

        public bool Equals(Point other)
        {
            return _name == other._name;
        }

        public string Leaving {  get { return new string( new char[]{ _name, _next.Name }); } }

        public override string ToString()
        {
            return string.Format("{0} (-> {1})", Name, _next.Name);
        }
    }
}
