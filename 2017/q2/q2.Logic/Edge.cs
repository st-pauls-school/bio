namespace q2.Logic
{
    public class Edge
    {
        readonly Dot _lower;
        readonly Dot _upper;
        bool _used = false;

        public Edge(Dot l, Dot u)
        {
            _lower = l;
            _upper = u;
        }

        public bool Used
        {
            get
            {
                return _used;
            }
            set
            {
                _used = value;
            }
        }
        public override string ToString()
        {
            return $"{_lower}-{_upper}";
        }

    }
}
