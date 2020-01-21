using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaComplex.Lib
{
    public class Plan
    {
        readonly IList<Room> _rooms;
        Room _currentRoom;

        public Plan(string v)
        {
            _rooms = new List<Room>();
            SetupRooms(v);
            _currentRoom = _rooms[0];
            
        }

        public List<string> Connections { get; }

        public string Moves(int v1)
        {
            for(int i = 0; i < v1; ++i)
                _currentRoom = _currentRoom.WhereNext();
            return _currentRoom.Name;
        }

        void SetupRooms(string v)
        {
            for (int i = 0; i < v.Length; ++i)
                _rooms.Add(new Room(('A' + i).ToString(), i==0));
            // todo: build the plan here 
        }
    }

    class Room
    {
        readonly string _name;
        IDictionary<Room, bool> _oddExits;
        bool _oddVisited;

        internal string Name { get { return _name; } }

        internal Room(string name, bool initialOdd = false)
        {
            _name = name;
            _oddVisited = initialOdd;
            _oddExits = new Dictionary<Room, bool>();
        }

        internal void AddConnection(Room r)
        {
            _oddExits.Add(r, true);
        }

        internal Room WhereNext()
        {
            Room rv = _oddVisited
                ? _oddExits
                    .Select(kvp => kvp.Key)
                    .OrderBy(k => k.Name)
                    .First()
                : _oddExits
                    .Where(kvp => !kvp.Value)
                    .Select(kvp => kvp.Key)
                    .OrderBy(k => k.Name)
                    .First();
            _oddExits[rv] = !_oddExits[rv];
            _oddVisited = !_oddVisited;
            return rv;
        }

        internal string Connections
        {
            get
            {
                return string.Join("", _oddExits.Select(kvp => kvp.Key).OrderBy(k => k));
            }
        }
    }
}
