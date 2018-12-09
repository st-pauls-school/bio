namespace q2.Logic
{
    public class Player
    {
        readonly int _identifier;
        readonly int _modifier;
        int _position;

        public Player(int identifier, int position, int modifier)
        {
            _identifier = identifier;
            _modifier = modifier;
            _position = position-1;
        }

        public void Move()
        {
            Add(_modifier);
        }

        public void Increment()
        {
            Add(1);         
        }

        void Add(int increase)
        {
            _position = (_position + increase) % 36;
        }

        public int Position {  get { return _position; } }
        public int Identifier {  get { return _identifier; } }

        public override string ToString()
        {
            return string.Format("{0}: [{1}]", Identifier, Position);
        }
    }
}
