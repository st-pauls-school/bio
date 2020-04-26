using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Migration.Tests")]
namespace Migration.Lib
{
    internal class Cell
    {
        readonly CoOrdinate _location;
        readonly IList<Cell> _neighbours;
        
        int _population; 

        internal CoOrdinate Location { get { return _location; } }

        internal Cell(CoOrdinate location){
            _location = location;
            _population = 0;
            _neighbours = new List<Cell>();
        }

        internal bool HaveNeighbours
        {
            get
            {
                return _neighbours.Count == 4;
            }
        }

        internal IEnumerable<CoOrdinate> IdentifyNeighbours()
        {
            foreach (Direction d in Enum.GetValues(typeof(Direction)))
            {
                int x = _location.X;
                int y = _location.Y;
                switch (d)
                {
                    case Direction.Up:
                        y--;
                        break;
                    case Direction.Down:
                        y++;
                        break;
                    case Direction.Left:
                        x--;
                        break;
                    case Direction.Right:
                        x++;
                        break;
                }
                yield return new CoOrdinate(x, y);
            }
        }

        internal void SetNeighbours(IList<Cell> neighbours)
        {
            foreach (Cell c in neighbours)
                _neighbours.Add(c);
        }

        internal void Disperse()
        {
            foreach (Cell c in _neighbours)
            {
                c.Increment();
            }
            _population -= 4;
        }
      
        public void Increment(){
            _population++;
        }

        public int Population { get { return _population; } }

        public bool IsOvercrowded { get { return _population >= 4; } }

        public override string ToString()
        {
            return string.Format("{0}: {1}", _location, _population);
        }
    }

}
