using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Migration.Lib
{
    public class Grid
    {
        readonly IList<int> _sequence;
        readonly int _iterations;
        readonly int _size;

        int _currentIteration; 
        int _currentIndex;
        int _currentPosition;
        
        readonly IDictionary<CoOrdinate, Cell> _cells;

        public Grid(int startingPosition, IList<int> sequence, int iterations, int size = 5)
        {
            _sequence = sequence;
            _iterations = iterations;
            _size = size;
            _currentIndex = 0;
            _currentPosition = startingPosition-1; // to sort out the off by one, I zero-index 
            _cells = new Dictionary<CoOrdinate, Cell>();
        }

        void Step(bool debug)
        {
            if (debug) Console.WriteLine("Add one to position: {0}", _currentPosition);
            CoOrdinate cp = CoOrdinate.FromIndex(_currentPosition);
            if (!_cells.ContainsKey(cp))
                _cells.Add(cp, new Cell(cp));
            _cells[cp].Increment();
            if (debug) Console.WriteLine("location {0} now has {1}", cp, _cells[cp].Population);
            while(_cells.Values.Any(c => c.IsOvercrowded))
            {
                // to avoid modifying the clousure 
                IList<Cell> cells = _cells.Values.Where(c => c.IsOvercrowded).Select(c => c).ToList();
                foreach (Cell c in cells)                
                {
                    // ask the cell if it knows its neighbours
                    if (!c.HaveNeighbours)
                    {
                        IList<Cell> neighbours = new List<Cell>();
                        foreach(CoOrdinate cc in c.IdentifyNeighbours())
                        {
                            if (!_cells.ContainsKey(cc))
                                _cells.Add(cc, new Cell(cc));
                            neighbours.Add(_cells[cc]);
                        }
                        c.SetNeighbours(neighbours);
                        // give the cells its neighbours if it doesn't 
                        // create the cells if necessary 
                    }// tell the cell to disperse to its neighbouts  
                    c.Disperse();                   
                }  
            }
            _currentPosition += _sequence[_currentIndex];
            _currentPosition %= (_size*_size);
            if (debug) Console.WriteLine("Add {0} makes {1}", _sequence[_currentIndex], _currentPosition);

            if (_sequence.Count > 1)
            {
                _currentIndex = (_currentIndex + 1) % _sequence.Count;
            }
        }

        public void Go(bool debug = false)
        {
            for(int i = 0; i < _iterations; ++i)
            {
                Step(debug);
                if (debug)
                    Console.WriteLine("Iteration {0}{1}{2}", i, Environment.NewLine, State());
            }
        }

        public string State()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < _size*_size; ++i)
            {
                CoOrdinate c = CoOrdinate.FromIndex(i);
                sb.Append((_cells.ContainsKey(c) ? _cells[c].Population : 0));
                if((i+1) % _size == 0)
                    sb.Append("//");             
            }
            return sb.ToString();
        }
    }

}
