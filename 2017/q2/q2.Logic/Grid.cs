using System;
using System.Collections.Generic;
using System.Text;

namespace q2.Logic
{
    public class Grid
    {
        IList<Dot> _dots;
        IList<Edge> _edges;
        IList<Square> _squares;
        IList<Player> _players;
        int _currentPlayer = -1; 


        public Grid(int p1, int m1, int p2, int m2)
        {
            _dots = new List<Dot>();
            // create the dots
            for(int i = 0; i < 36; i++)
                _dots.Add(new Dot(i));
            // create the squares, then assign to edges on the four sides 
            _squares = new List<Square>();
            for (int i = 0; i < 25; i++)
                _squares.Add(new Square());

            // create the edges, and then assign to the dots at each end 
            _edges = new List<Edge>();
            int edgecounterx = 0;
            for (int i = 0; i < 36; i++)
            {
                // create the horizontal edges, adding them to the appropriate squares
                if ((i + 1) % 6 != 0)
                {
                    Edge e = new Edge(_dots[i], _dots[i + 1]);
                    _edges.Add(e);
                    _dots[i + 1].AddEdge(Direction.Left, e);
                    _dots[i].AddEdge(Direction.Right, e);
                    if (edgecounterx < 25)
                        _squares[edgecounterx].AddEdge(Direction.Up, e);
                    if (edgecounterx >= 5)
                        _squares[edgecounterx-5].AddEdge(Direction.Down, e);
                    edgecounterx++;
                }
                // create the vertical edges, adding them to the appropriate squares
                if (i < 30)
                {
                    Edge e = new Edge(_dots[i], _dots[i + 6]);
                    _edges.Add(e);
                    _dots[i + 6].AddEdge(Direction.Up, e);
                    _dots[i].AddEdge(Direction.Down, e);
                    int s = i - (i / 6);
                    if (i % 6 < 5 )
                        _squares[s].AddEdge(Direction.Left, e);
                    if (i % 6  > 0)
                        _squares[s-1].AddEdge(Direction.Right, e);
                }
            }
            // create the players 
            _players = new List<Player> { new Player(1, p1, m1), new Player(2, p2, m2) };
             
        }

        public bool Move(bool changePlayer)
        {
            if(changePlayer)
                _currentPlayer = (_currentPlayer + 1) % 2;
            Player player = _players[_currentPlayer];
            player.Move();
            while (true)
            {
                Direction dir = Direction.Up;
                // try to move
                for(int i = 0; i < 4; i++)
                {
//                    Console.Write("player {0}: {1} from {2} ", player.Identifier, dir.ToString(), player.Position);
                    if (_dots[player.Position].AssignEdge(dir))
                    {
                        bool successful = false;
                        foreach (Square s in _squares)
                            if (s.Assign(player))
                                successful = true;
//                        Console.WriteLine("ok. square? {0}", successful);
                        // return if we were able to assign any squares 
                        return successful;
                    }
//                    Console.WriteLine("no");
                    dir = (Direction)(((int)dir + (player.Identifier == 1 ? 1 : 3))%4);
                }

                // if unsuccessful, increment and try again 
                player.Increment();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int p1 = 0;
            int p2 = 0;
            for(int i = 0; i < 25; i++)
            {
                if (i > 0 && i % 5 == 0)
                    sb.Append(Environment.NewLine);
                string s = _squares[i].ToString();
                if (s == "X") p1++;
                if (s == "O") p2++;
                sb.Append(s);

            }
            sb.Append(string.Format("{2}{0} {1}", p1, p2, Environment.NewLine));
            return sb.ToString();
        }

        public string Result
        {
            get
            {
                int p1 = 0;
                int p2 = 0;
                for (int i = 0; i < 25; i++)
                {
                    string s = _squares[i].ToString();
                    if (s == "X") p1++;
                    if (s == "O") p2++;
                }
                return $"{p1} {p2}";
            }
        }

        public void Play(int moves)
        {
            bool successful = false;
            for (int i = 0; i < moves; i++)
            {
                successful = Move(!successful);
            }

        }
    }
}
