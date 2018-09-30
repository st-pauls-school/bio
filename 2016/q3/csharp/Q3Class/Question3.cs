using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3Class
{
    public class Question3 : IQuestion3
    {
        public int Run(int p, int i, int n, int w)
        {
            List<Parcel> parcels = new List<Parcel>();            
            for(int iCounter = 1; iCounter <= i; iCounter ++)
            {
                parcels.Add(new Parcel(n, w));
            }
            for(int itemCounter = 1; itemCounter < (n - (p-1)); itemCounter++)
            {
                List<Parcel> newParcels = new List<Parcel>();
                foreach (Parcel pa in parcels)
                {
                    Parcel pa2 = new Parcel(pa);
                    if (pa2.AddItem(itemCounter))
                        newParcels.Add(pa2);
                }
                parcels = newParcels;
            }

            foreach (Parcel pa in parcels)
            {
                Debug.WriteLine(pa.ToString());
            }

            return 0;
        }
    }
        
    public class Parcel
    {
        protected IEnumerable<int> Items {  get { return _items; } }
        protected int LimitCount { get { return _limitCount; } }
        protected int LimitWeight { get { return _limitWeight; } }
        protected int Weight {  get { return _items.Sum(); } }
        protected bool Full {  get { return _full; } }

        IList<int> _items;
        readonly int _limitCount;
        readonly int _limitWeight;
        bool _full;
        int _currentLargest = 0;

        public Parcel(int limitCount, int limitWeight)
        {
            _limitCount = limitCount;
            _limitWeight = limitWeight;
            _items = new List<int>();
            _full = false;
        }

        public Parcel(Parcel p) : this(p.LimitCount, p.LimitWeight)
        {
            _items = new List<int>(p.Items);
        }

        public bool AddItem(int item)
        {
            if (_full) return false;
            if (item < _currentLargest) return false;
            if (Weight > _limitWeight || _items.Count + 1 > _limitCount)
                return false;
            _items.Add(item);
            if (Weight == _limitWeight)
                _full = true;
            return true;
        }

        public override string ToString()
        {
            return _items.Select(i => i.ToString()).Aggregate((a, b) => a + " " + b);            
        }
    }

}
