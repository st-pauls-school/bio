using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("case 1");
            foreach(string s in BattleshipPlacing(10,5,9999))
                Console.WriteLine(s);
            Console.WriteLine("case 6");
            foreach(string s in BattleshipPlacing(16807,1,9999))
                Console.WriteLine(s);

        }

        static IList<string> BattleshipPlacing(uint a, uint c, uint m, bool output = false)
        {
            IList<int> ships = new List<int> { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1};
            IList<IList<bool>> grid = new List<IList<bool>>();
            for(int i = 0; i < 10; ++i) {
                IList<bool> row = new List<bool>();
                for(int j = 0; j < 10; ++j)
                    row.Add(false);
                grid.Add(row);
            }
            // when we add a ship we need to add also the spaces around it 
            // we need to generate a list, validate that none are already true
            // then set them all to true 

            uint r = 0;
            int x, y;
            IList<string> placements = new List<string>();
            IList<Tuple<int,int>> surrounding = new List<Tuple<int,int>>();
            IList<Tuple<int,int>> ship_placing = new List<Tuple<int,int>>();
            int shipindex = 0;
            while(shipindex < ships.Count) {
            
                // generate r (using a c m r)
                r = (a * r + c) % m;
                // for the r generate x and y 
                x = (int)(r % 10);
                y = (int)(((r-x) % 100) / 10);

                // re-generate r 
                r = (a * r + c) % m;
                // create H or V 
                bool isHoriz = (r % 2 == 0);

                // for this ship generate the target spaces
                surrounding.Clear();
                ship_placing.Clear();
                // is the ship on the board   
                if(isHoriz && x+ships[shipindex]-1 >= 10 || !isHoriz && y+ships[shipindex]-1 >= 10)
                    continue;

                // calculate the possible ship cells 
                // and the surrounding spaces
                for(int shipcount = 0; shipcount < ships[shipindex]; ++shipcount)
                    for(int offsetx = -1; offsetx <= 1; ++offsetx)
                        for(int offsety = -1; offsety <= 1; ++offsety)
                        {
                            Tuple<int,int> cell = new Tuple<int, int>(x+ (isHoriz ? shipcount:0) + offsetx, y+ (!isHoriz ? shipcount: 0)+offsety);
                            surrounding.Add(cell);
                            if(offsetx == 0 && offsety == 0)
                                ship_placing.Add(cell);                            
                        }
                // filter out any necessarily false that are off the board 
                surrounding = surrounding
                    .Where(xy => xy.Item1 >=0 && xy.Item1 < 10 && xy.Item2 >=0 && xy.Item2 < 10).ToList();
                    
                // are any currently true (i.e. all must be false) - be careful with the x and y identification 
                if(surrounding
                    .All(xy => grid[xy.Item2][xy.Item1] == false))
                    // if not 
                {
                    string placement = string.Format("{0} {1} {2}", x, y, isHoriz ? "H" : "V");
                    // set spots to true 
                    foreach(Tuple<int,int> xy in ship_placing)
                        grid[xy.Item2][xy.Item1] = true;

                    if(output) {
                        for(int oy = 9; oy >=0 ; --oy)
                        {
                            for(int ox = 0; ox < 10; ++ox)
                                Console.Write(grid[oy][ox] ? "X" : ".");
                            Console.WriteLine();
                        }
                        Console.WriteLine(placement);
                    }
                     // add candidate to list of strings 
                     placements.Add(placement);
                    ++shipindex;
                }
            }
            // return list of candidates 
            return placements; 
        } 
    }
}


