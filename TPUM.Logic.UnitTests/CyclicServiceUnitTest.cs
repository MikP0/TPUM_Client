using System;
using System.Reactive.Linq;
using System.Reactive;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TPUM.Logic.UnitTests
{
    [TestClass]
    public class CyclicServiceUnitTest
    {
        [TestMethod]
        public void ReactiveTimerTest()
        {
            using (CyclicService _cyclicTimer = new CyclicService(TimeSpan.FromSeconds(1)))
            {
                int counter = 0;

                IObservable<System.Reactive.EventPattern<CyclicEvent>> _tickObservable = Observable.FromEventPattern<CyclicEvent>(_cyclicTimer, "Tick");

                Assert.AreEqual(0, counter);

                using (IDisposable _observer = _tickObservable.Subscribe(x => counter++))
                {
                    _cyclicTimer.Start();
                    System.Threading.Thread.Sleep(2000);                               
                }

                Assert.AreNotEqual(0, counter);
            }
        }
    }
}
