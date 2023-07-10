using Common.Domain.Utils;

namespace BookStore.Test.Share.TestDoubles
{
    public class StubUtcClock : IClock
    {
        public static StubUtcClock WhichSetsNowAs(DateTime datetime)
        {
            return new StubUtcClock(datetime);
        }

        public static StubUtcClock Default => new(DateTime.UtcNow);
        private StubUtcClock(DateTime now)
        {
            Now = now;
        }

        public DateTime Now { get; private set; }

        public void TimeTravelTo(DateTime target)
        {
            Now = target;
        }
        public void TimeTravelToSomeDateAfter(DateTime date)
        {
            Now = date.AddDays(1);
        }
        public void TimeTravelToSomeDateBefore(DateTime date)
        {
            Now = date.AddDays(-1);
        }
    }
}