using System;

namespace TPUM.Logic
{
    public class CyclicEvent : EventArgs
    {
        public CyclicEvent(long counter)
        {
            Counter = counter;
        }

        public long Counter { get; private set; }
    }
}
