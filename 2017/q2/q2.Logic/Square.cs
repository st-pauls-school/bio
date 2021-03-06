﻿using System.Collections.Generic;

namespace q2.Logic
{
    public class Square
    {
        IDictionary<Direction, Edge> _edges;
        Player _owner = null;

        public Square()
        {
            _edges = new Dictionary<Direction, Edge>();
        }

        public void AddEdge(Direction d, Edge e)
        {
            _edges.Add(d, e);
        }

        public bool Assign(Player player)
        {
            // if it already has an owner, return false 
            if (_owner != null)
                return false;
            // check all four edges
            foreach(KeyValuePair<Direction, Edge> kv in _edges)
            {
                // if any are unused, return false 
                if (!kv.Value.Used)
                    return false;
            }
            // assign it to the player 
            _owner = player;
            return true;
        }

        public Player Owner {  get { return _owner; } }

        public override string ToString()
        {
            return _owner != null
                ? _owner.Identifier == 1 ? "X" : "O"
                : "*";
        }
    }
}
