using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace TPUM.Logic
{
    public class CyclicService : IDisposable
    {
        public TimeSpan Period { get; private set; }

        public event EventHandler<CyclicEvent> Tick;

        public CyclicService(TimeSpan period)
        {
            Period = period;
        }

        public void Start()
        {
            IObservable<long> _TimerObservable = Observable.Interval(Period);
            m_TimerSubscription = _TimerObservable.ObserveOn(Scheduler.Default).Subscribe(c => RaiseTick(c));
        }

        private IDisposable m_TimerSubscription = null;

        private void RaiseTick(long counter)
        {
            Tick?.Invoke(this, new CyclicEvent(counter));
        }

        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
