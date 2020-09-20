using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Migration.Tests")]
namespace Migration.Lib
{
    internal class CoOrdinate : IEquatable<CoOrdinate> {
        readonly int _x;
        readonly int _y;

        public int X { get { return _x; } }
        public int Y { get { return _y; } }

        readonly int _size;

        internal CoOrdinate(int x, int y, int size = 5)
        {
            _x = x;
            _y = y;
            _size = size;
        }

        public bool Equals(CoOrdinate other)
        {
            return GetHashCode() == other.GetHashCode();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }
        }

        public int Index 
        { 
            get 
            { 
                if (X < 0 || X >= _size || Y < 0 || Y >= _size)
                    return -1;
                return _size*Y + X;
            }
        }

        public override string ToString()
        {
            return string.Format("({0},{1}) [{2}]", X, Y, Index);
        }

        public static CoOrdinate FromIndex(int index, int size = 5)
        {
            var c = new CoOrdinate(index%size, (index/size), size);
            return c;
        } 
    }
}
