using System.Collections.Generic;
using System.Linq;

namespace AlphaComplex.Lib
{
    public class Plan
    {
        readonly IList<Room> _rooms;
        Room _currentRoom;
        int _totalMoves;

        public Plan(string v)
        {
            _rooms = new List<Room>();
            SetupRooms(v);
            _currentRoom = _rooms[0];
            _rooms[0].VisitMe();
            _totalMoves = 0;
            
        }

        public List<string> Connections { get { return _rooms.Select(r => r.ConnectionString).ToList(); } }

        public string Moves(int targetMoveCount)
        {
            for(; _totalMoves < targetMoveCount; ++_totalMoves)
                _currentRoom = _currentRoom.WhereNext();
            return _currentRoom.Name;
        }

        void SetupRooms(string v)
        {
            string plan = v;

            /* Alpha Complex consists of r (r ≥ 3) rooms, identified by the first r letters of the alphabet. The spy is in
            possession of a secret plan, giving the connections between the rooms. This plan is an ordered list of r-2
            letters and the spy can construct a map of the complex as follows:
            • The spy will choose the first room alphabetically which has not yet been chosen and which is not in
            the plan. The chosen room is connected to the first room in the plan. The first room is then
            removed from the plan;
            • The above step is repeated until the plan is empty;
            • There will be two rooms which have not yet been chosen. These two rooms are connected together.
            If two rooms are connected, each room has an exit to the other room.
            */

            // create r+2 rooms 
            for (int i = 0; i < v.Length+2; ++i)
                _rooms.Add(new Room(((char)('A' + i)).ToString()));
            IList<char> notChosen = _rooms.Select(r => r.Name[0]).ToList();

            while (plan.Length > 0)
            {
                char firstAlphabeticallyNotInPlan = ' ';
                for(int i =0; i < _rooms.Count; ++i)
                {
                    char c = (char)('A' + i);
                    if (!plan.Contains(c) && notChosen.Contains(c))
                    {
                        firstAlphabeticallyNotInPlan = c;
                        break;
                    }
                }
                Connect(plan[0].ToString(), firstAlphabeticallyNotInPlan.ToString());
                plan = plan.Substring(1);
                notChosen.Remove(firstAlphabeticallyNotInPlan);
            }
            Connect(notChosen[0].ToString(), notChosen[1].ToString());


        }

        void Connect(string a, string b)
        {
            Room roomA = _rooms.Where(r => r.Name == a).First();
            Room roomB = _rooms.Where(r => r.Name == b).First();
            roomA.AddConnection(roomB);
            roomB.AddConnection(roomA);
        }
    }
}
