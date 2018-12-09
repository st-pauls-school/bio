using System.Collections.Generic;

namespace q2.Logic
{
    public class Dot
    {
        IDictionary<Direction, Edge> _edges;
        readonly int _identifier;

        public Dot(int id)
        {
            _identifier = id;
            _edges = new Dictionary<Direction, Edge>();
        }

        public void AddEdge(Direction d, Edge e)
        {
            _edges.Add(d, e);
        }

        public Edge GetEdge(Direction d)
        {
            return _edges.ContainsKey(d) ? _edges[d] : null;
        }

        public bool AssignEdge(Direction d)
        {
            // if there isn't an edge, return false
            if (!_edges.ContainsKey(d))
                return false;
            // if the edge is already used, return false
            if (_edges[d].Used)
                return false;

            // set the edge to used and return true 
            _edges[d].Used = true;
            return true;
        }

        public override string ToString()
        {
            return string.Format("d{0}", _identifier);
        }
    }
}
