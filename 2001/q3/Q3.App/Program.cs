using System;
using System.Collections.Generic;
using System.Linq;

namespace Q3.App
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(12 == SpaceOddity(new List<int> { 1,2,4,5}));

            // The mark scheme secret situations 
            Console.WriteLine(10 == SpaceOddity(new List<int> { 10}));
            Console.WriteLine(13 == SpaceOddity(new List<int> { 8, 13}));
            Console.WriteLine(25 == SpaceOddity(new List<int> { 3, 7, 15}));
            Console.WriteLine(80 == SpaceOddity(new List<int> { 10, 15, 20, 25}));
            Console.WriteLine(19 == SpaceOddity(new List<int> { 2, 3, 5, 8}));
            Console.WriteLine(252 == SpaceOddity(new List<int> { 4, 23, 40, 41, 80, 90}));
            Console.WriteLine(101 == SpaceOddity(new List<int> { 1, 6, 8, 19, 20, 30, 40}));
            Console.WriteLine(1287 == SpaceOddity(new List<int> { 99, 99, 99, 99, 99, 99, 99, 99}));
            Console.WriteLine(375 == SpaceOddity(new List<int> { 1, 20, 38, 39, 95, 96, 97, 98}));
            Console.WriteLine(165 == SpaceOddity(new List<int> { 11, 12, 13, 14, 15, 16, 17, 18}));

            /*
            // Could be worth abstracting this into its own function 

            Console.Write("Number: ");
            string numInput = Console.ReadLine();
            int numOfAstronauts = Convert.ToInt32(numInput);
            IList<Astronaut> astronauts = new List<Astronaut>();
            for(int i = 0; i < numOfAstronauts; ++i)
            {   
                Console.Write("Astronaut {0}: ", i);
                string astroInput = Console.ReadLine();
                int minutes = Convert.ToInt32(astroInput);
                astronauts.Add(new Astronaut(minutes));                
            }
*/
        }
        
        // Takes a list with the integer values for the times of the astronauts. 
        public static int SpaceOddity(IList<int> times)
        {
            IList<Astronaut> astronauts = times.Select(x => new Astronaut(x)).ToList();            
            State initialState = new State(astronauts, new List<Astronaut>(), 0, true);
            State mostSuccessfulState = null ;
            Queue<State> stateQueue = new Queue<State>();
            stateQueue.Enqueue(initialState);
            // the hashes is a dictionary, with a value of the cost so that if we have seen this configuration before, we will allow it,
            // iff the newer version has a lower cost 
            IDictionary<int,int>hashes = new Dictionary<int, int> { { initialState.GetHashCode(), 0 } };

            while(stateQueue.Count > 0)
            {
                State candidate = stateQueue.Dequeue();
                if(candidate.Successful)
                {
                    // note the nested if 
                    if(mostSuccessfulState == null || candidate.Minutes < mostSuccessfulState.Minutes)
                    {
                        mostSuccessfulState = candidate;
                    }
                }
                else
                {
                    // we're only interested in the next generation if the candidate could be the stem for the most successful candidate, 
                    // so if there is a successful candidate and it is already cheaper, we can ignore this candidate 
                    if(mostSuccessfulState == null || candidate.Minutes < mostSuccessfulState.Minutes)
                    {
                        foreach(State child in candidate.GenerateNextSteps())
                        {                            
                            // have we seen the state before? 
                            // is this a lower cost? 
                            int hc = child.GetHashCode(); 
                            if(!hashes.ContainsKey(hc) || hashes[hc] > child.Minutes)
                            {
                                stateQueue.Enqueue(child);
                                if(hashes.ContainsKey(hc))
                                    hashes[hc] = child.Minutes;
                                else
                                    hashes.Add(hc, child.Minutes);
                                // might it be worth going through the queue and removing the more expensive states? 
                            }
                        }
                    }
                }

            }

            return mostSuccessfulState == null ? -1 : mostSuccessfulState.Minutes;
        }
    
    }



    class State
    {        
        readonly IList<Astronaut> _pod;
        readonly IList<Astronaut> _ship;
        readonly int _minutes;
        readonly bool _packIsAtPod;

        public bool Successful { get { return _pod.Count == 0;}} 
        public int Minutes { get { return _minutes; }}

        public State(IList<Astronaut> p, IList<Astronaut> s, int minutes, bool packIsAtPod)
        {
            _pod = p.Select(x => x).OrderBy(x => x.Minutes).ToList();
            _ship = s.Select(x => x).OrderBy(x => x.Minutes).ToList();
            _minutes = minutes;
            _packIsAtPod = packIsAtPod;
        }

        public IEnumerable<State> GenerateNextSteps()
        {
            // There's a lot of ugly aliasing cloning to do here - it would be nice if C# explicitly implemented a proper DeepCopy 

            IList<Astronaut> from = _packIsAtPod ? _pod : _ship;
            IList<Astronaut> to = _packIsAtPod ? _ship : _pod;

            // first let's move individuals 
            for(int i = 0 ; i < from.Count; ++i)
            {
                IList<Astronaut> fromcopy = from.Select(x => x).ToList();    
                IList<Astronaut> tocopy = to.Select(x => x).ToList();    

                Astronaut mover = fromcopy[i];
                fromcopy.RemoveAt(i);
                IList<Astronaut> newFrom = fromcopy.Select(a => a).ToList();
                IList<Astronaut> newTo = tocopy.Select(a => a).ToList();
                tocopy.Add(mover);

                IList<Astronaut> newp = _packIsAtPod ? fromcopy : tocopy;
                IList<Astronaut> news = _packIsAtPod ? tocopy : fromcopy;


                State st = new State(newp, news, _minutes + mover.Minutes, !_packIsAtPod);
                yield return st;
            }

            // now move pairs            
            for(int i = 0 ; i < from.Count - 1; ++i)
            {
                // Yes, DRY, I know 
                for(int j = i+1 ; j < from.Count; ++j)
                {
                    IList<Astronaut> fromcopy = from.Select(x => x).ToList();    
                    IList<Astronaut> tocopy = to.Select(x => x).ToList();    

                    Astronaut mover1 = fromcopy[i];
                    Astronaut mover2 = fromcopy[j];
                    // remove the higher index first, otherwise OBOE
                    fromcopy.RemoveAt(j);
                    fromcopy.RemoveAt(i);

                    IList<Astronaut> newFrom = fromcopy.Select(a => a).ToList();
                    IList<Astronaut> newTo = tocopy.Select(a => a).ToList();
                    tocopy.Add(mover1);
                    tocopy.Add(mover2);

                    IList<Astronaut> newp = _packIsAtPod ? fromcopy : tocopy;
                    IList<Astronaut> news = _packIsAtPod ? tocopy : fromcopy;

                    State st = new State(newp, news, _minutes + (mover1.Minutes > mover2.Minutes ? mover1.Minutes : mover2.Minutes), !_packIsAtPod);
                    yield return st;
                }
            }
        }

        public override string ToString()
        {
            // no particular reason, but it does make debugging and tracing neater 
            return string.Format("[{0}] {2} [{1}] / {3}", 
                string.Join(',', _pod),
                string.Join(',', _ship), 
                _packIsAtPod ? "->" : "<-", 
                _minutes) ;
        }

        public override int GetHashCode()
        {
            // ignoring the cost, just the positions of the astronauts and the direction of travel 
            unchecked 
            {
                int hash = _packIsAtPod ? 17 : 13;
                // we can assume that the lists are sorted.
                int items = _pod.Count + _ship.Count;
                foreach(Astronaut a in _pod)
                {
                    hash = (hash * 7) + a.Minutes;
                }
                foreach(Astronaut a in _pod)
                {
                    hash = (hash * 7) + (items * a.Minutes);
                }
                return hash;
            }
        }
    }

    class Astronaut
    {
        // an immutable object 
        readonly int _minutes;
        public int Minutes { get { return _minutes; }}

        public Astronaut(int minutes)
        {
            _minutes = minutes;
        }

        public override string ToString()
        {
            return string.Format("{0}", _minutes);
        }
    }
}
