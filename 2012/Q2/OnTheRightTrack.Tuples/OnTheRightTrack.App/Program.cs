using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace OnTheRightTrack.App
{
    class Program
    {
        static void Main(string[] args)
        {
            // from the question paper 
            Debug.Assert(PartA("", "AE", 6, true) == "FA");
            Debug.Assert(PartA("GHIJKL", "AE", 6, true) == "FA");
            Debug.Assert(PartA("GHIJKL", "AE", 100, true) == "VP");

            // and the mark scheme
            Debug.Assert(PartA("ABCDEF", "HP", 1) == "PV");
            Debug.Assert(PartA("ABCDEF", "PH", 1) == "HB");
            Debug.Assert(PartA("AEFMNO", "DK", 13) == "SK");
            Debug.Assert(PartA("AEFMNS", "DK", 13) == "SJ");
            Debug.Assert(PartA("ABCDEF", "GO", 100) == "QI");
            Debug.Assert(PartA("FJLMQU", "GO", 100) == "RJ");
            Debug.Assert(PartA("FDEGNQ", "AE", 9876) == "WQ");
        }


        static string PartA(string flipFlops, string initialPattern, int steps, bool debug = false)
        {
            IList<(char node, char straight, char left, char right)> ltbs = new List<(char, char, char, char)>
                {
                    ('A','D','E','F'),
                    ('B','C','G','H'),
                    ('C','B','I','J'),
                    ('D','A','K','L'),
                    ('E','A','M','N'),
                    ('F','A','N','O'),
                    ('G','B','O','P'),
                    ('H','B','P','Q'),
                    ('I','C','Q','R'),
                    ('J','C','R','S'),
                    ('K','D','S','T'),
                    ('L','D','T','M'),
                    ('M','U','L','E'),
                    ('N','U','E','F'),
                    ('O','V','F','G'),
                    ('P','V','G','H'),
                    ('Q','W','H','I'),
                    ('R','W','I','J'),
                    ('S','X','J','K'),
                    ('T','X','K','L'),
                    ('U','V','M','N'),
                    ('V','U','O','P'),
                    ('W','X','Q','R'),
                    ('X','W','S','T')
                };

            IDictionary<char, char> currentCurvedConnections = new Dictionary<char, char>();
            foreach(var triple in ltbs)
            {
                currentCurvedConnections.Add(triple.node, triple.left);
            }
                        
            (char f, char t) currentEdge = (initialPattern[0], initialPattern[1]); 
            
            for(int i = 0; i < steps; ++i)
            {
                // if the from node is equal to the straight connection for the to node 
                bool IsStraight = ltbs.First(triple => triple.node == currentEdge.t).straight == currentEdge.f;

                (char f, char t) nextEdge; 
                // in the triple, we know where we're coming from and going to and which direction 
                if (IsStraight)
                {
                    // we need to take the left or the right edge, depending on the current connection 
                    nextEdge = (currentEdge.t, currentCurvedConnections[currentEdge.t]);
                    
                    // is it a flip flop point? 
                    if(flipFlops.Contains(currentEdge.t))
                    {
                        var n = ltbs.First(defn => defn.node == currentEdge.t);
                        if (n.left == currentCurvedConnections[currentEdge.t])
                            currentCurvedConnections[currentEdge.t] = n.right;
                        else
                            currentCurvedConnections[currentEdge.t] = n.left;
                    }
                }
                else
                {
                    // we've come in along the curved edge 
                    var n = ltbs.First(defn => defn.node == currentEdge.t);
                    nextEdge = (currentEdge.t, n.straight);

                    // if it's a lazy point 
                    if(!flipFlops.Contains(currentEdge.t))
                    {
                        // we need to update the current connection in the reverse direction 
                        currentCurvedConnections[currentEdge.t] = currentEdge.f;
                    }

                }

                currentEdge = nextEdge;
                if(debug)
                    Console.WriteLine(currentEdge);
                
            }

            return $"{currentEdge.f}{currentEdge.t}";


        }
    }
}
