using System;
using System.Collections.Generic;
using System.Linq;

namespace AlphaComplex.Lib
{
    /// <summary>
    /// The Room class - can be internal as only visible within the plan. 
    /// </summary>
    class Room : IComparable<Room>
    {
        readonly string _name;
        IDictionary<Room, int> _connections;
        int _cVisited;

        internal string Name { get { return _name; } }

        internal Room(string name)
        {
            _name = name;
            _cVisited = 0;
            _connections = new Dictionary<Room, int>();
        }

        internal void AddConnection(Room r)
        {
            _connections.Add(r, 0);
        }

        internal void VisitMe()
        {
            _cVisited++;
        }

        internal Room WhereNext()
        {
            /*
             * The spy moves between rooms according to the following rules:
                • If they have visited the room an odd number of times, they will leave through the exit which is
                marked with the first letter alphabetically;
                • If they have visited the room an even number of times, they will find the first exit alphabetically that
                they have left through an odd number of times. If that is the last exit alphabetically in this room
                they will leave through it, otherwise they will leave through the next exit alphabetically.
             */
            Room rv;
            if (_cVisited % 2 == 1)
                rv = _connections
                    .Select(kvp => kvp.Key)
                    .OrderBy(k => k.Name)
                    .First();
            else
            {
                Room firstOdd = _connections
                   .Where(kvp => kvp.Value % 2 == 1)
                   .Select(kvp => kvp.Key)
                   .OrderBy(k => k.Name)
                   .First();
                IList<Room> laterRooms = 
                    _connections
                        .Where(kvp => kvp.Key.Name.CompareTo(firstOdd.Name) >= 0)
                        .Select(kvp => kvp.Key)
                        .OrderBy(r => r.Name)
                        .ToList();
                rv = laterRooms[laterRooms.Count > 1 ? 1 : 0];

            }
            // we've used this door, so increment the count
            _connections[rv]++;
            // we're visting the next room so 
            rv.VisitMe();
            return rv;
        }

        internal string ConnectionString
        {
            get
            {
                if (_connections.Count == 0)
                    return string.Empty;
                return string.Join("", _connections.Select(kvp => kvp.Key.Name).OrderBy(k => k));
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Name, ConnectionString);
        }

        public int CompareTo(Room other)
        {
            return ConnectionString.CompareTo(other.ConnectionString);
        }
    }
}
