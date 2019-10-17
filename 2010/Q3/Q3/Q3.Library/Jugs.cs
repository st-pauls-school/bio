using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3.Library
{

    public class Jug1State : IEquatable<Jug1State>
    {
        public Jug JugA { get; private set; }
        public int Moves { get; private set; }

        public Jug1State(Jug a, int m)
        {
            JugA = a;
            Moves = m;
        }

        public bool Equals(Jug1State other)
        {
            return JugA.Current == other.JugA.Current;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Moves, JugA);
        }
    }

    public class Jug2State : Jug1State, IEquatable<Jug2State>
    {
        public Jug JugB { get; private set; }
        public Jug2State(Jug a, Jug b, int m) : base(a, m)
        {
            JugB = b;
        }

        public bool Equals(Jug2State other)
        {
            return JugB.Current == other.JugB.Current && base.Equals(other);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", base.ToString(), JugB);
        }
    }
    public class Jug3State : Jug2State, IEquatable<Jug3State>
    {
        public Jug JugC { get; private set; }
        public Jug3State(Jug a, Jug b, Jug c, int m) : base(a, b, m)
        {
            JugC = c;
        }

        public bool Equals(Jug3State other)
        {
            return JugC.Current == other.JugC.Current && base.Equals(other);
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", base.ToString(), JugC);
        }
    }


    public class Jugs
    {

        readonly Queue<Jug3State> _queue;
        readonly IList<Jug3State> _visited;
        readonly int _target;
        readonly int _numberOfJugs;

        public int QueueLength => _queue.Count;

        public Jugs(int target, int a, int b=0, int c=0)
        {
            _queue = new Queue<Jug3State>();
            _queue.Enqueue(new Jug3State(new Jug(a), new Jug(b), new Jug(c), 0));
            _target = target;
            if (b == 0)
                _numberOfJugs = 1;
            else if (c == 0)
                _numberOfJugs = 2;
            else
                _numberOfJugs = 3;
            _visited = new List<Jug3State>();
        }

        public int Go()
        {
            int? rv;
            do
            {
                rv = Generate();
            } while (rv == null);
            return rv.Value;

        }

        static Jug3State StateClone(Jug3State head)
        {
            return new Jug3State(head.JugA.Clone(), head.JugB.Clone(), head.JugC.Clone(), head.Moves + 1);
        }

        int? Generate()
        {
            Jug3State head = _queue.Dequeue();
            _visited.Add(head);

            // for all states there are 2 actions
            // empty a
            Jug3State emptyA = StateClone(head);
            emptyA.JugA.Empty();
            SensibleEnqueue(emptyA);
            // fill a
            Jug3State fillA = StateClone(head);
            fillA.JugA.Fill();
            if (_target == fillA.JugA.Current)
                return fillA.Moves;
            SensibleEnqueue(fillA);

            // if there are at least two jugs, there are 4 new actions
            if (_numberOfJugs >= 2)
            {
                // empty b
                Jug3State emptyB = StateClone(head);
                emptyB.JugB.Empty();
                SensibleEnqueue(emptyB);

                // fill b 
                Jug3State fillB = StateClone(head);
                fillB.JugB.Fill();
                if (_target == fillB.JugA.Current)
                    return fillB.Moves;
                SensibleEnqueue(fillB);

                // transfer a->b
                Jug3State aToB = StateClone(head);
                aToB.JugA.TransferTo(aToB.JugB);
                if (_target == aToB.JugA.Current || _target == aToB.JugB.Current)
                    return aToB.Moves;
                SensibleEnqueue(aToB);

                // transfer b-> a 
                Jug3State bToA = StateClone(head);
                bToA.JugB.TransferTo(bToA.JugA);
                if (_target == bToA.JugA.Current || _target == bToA.JugB.Current)
                    return bToA.Moves;
                SensibleEnqueue(bToA);
            }

            // inductively
            // if there are at least 3 jugs 
            if (_numberOfJugs >= 3)
            {
                // empty c
                Jug3State emptyC = StateClone(head);
                emptyC.JugC.Empty();
                SensibleEnqueue(emptyC);

                // fill C 
                Jug3State fillC = StateClone(head);
                fillC.JugC.Fill();
                if (_target == fillC.JugA.Current)
                    return fillC.Moves;
                SensibleEnqueue(fillC);

                // transfer a->c
                Jug3State aToC = StateClone(head);
                aToC.JugA.TransferTo(aToC.JugC);
                if (_target == aToC.JugA.Current || _target == aToC.JugC.Current)
                    return aToC.Moves;
                SensibleEnqueue(aToC);

                // transfer c-> a 
                Jug3State cToA = StateClone(head);
                cToA.JugC.TransferTo(cToA.JugA);
                if (_target == cToA.JugA.Current || _target == cToA.JugC.Current)
                    return cToA.Moves;
                SensibleEnqueue(cToA);

                // transfer B->c
                Jug3State bToC = StateClone(head);
                bToC.JugB.TransferTo(bToC.JugC);
                if (_target == bToC.JugB.Current || _target == bToC.JugC.Current)
                    return bToC.Moves;
                SensibleEnqueue(bToC);

                // transfer c-> B 
                Jug3State cToB = StateClone(head);
                cToB.JugC.TransferTo(cToB.JugB);
                if (_target == cToB.JugB.Current || _target == cToB.JugC.Current)
                    return cToB.Moves;
                SensibleEnqueue(cToB);
            }

            return null;
        }

        public void SensibleEnqueue(Jug3State candidate)
        {
            foreach (Jug3State state in _visited)
            {
                if(state.Equals(candidate))
                    return;
            }
            foreach (Jug3State state in _queue)
            {
                if (state.Equals(candidate))
                    return;
            }
            _queue.Enqueue(candidate);
        }
    }

    public class Jug
    {
        readonly int _size;
        int _current;

        public int Capacity { get { return _size; } }
        public int Current {  get { return _current; } }

        public int Available {  get { return _size - _current; } }

        public Jug(int size, int current = 0)
        {
            _size = size;
            _current = current;
        }

        public void Fill()
        {
            _current = _size;
        }

        public void Empty()
        {
            _current = 0;
        }

        public int TopUp(int amount)
        {
            if(amount <= Available)
            {
                _current += amount;
                return 0;
            }

            int remaining = amount - Available;
            _current = _size;
            return remaining;
        }

        public void TransferTo(Jug j)
        {
            int leftover = j.TopUp(_current);
            _current = leftover;
        }

        public Jug Clone()
        {
            return new Jug(Capacity, Current);
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", _current, _size);
        }
    }
}
