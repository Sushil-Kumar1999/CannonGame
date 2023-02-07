namespace CannonGame.Tests;

public class TimeTrackerTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1000, 1)]
    [InlineData(2300, 2)]
    [InlineData(3500, 3)]
    [InlineData(9999, 10)]
    public void GivenStartTimerIsCalled_WhenNMillisecondsLapse_ThenTimeIsReturned(int executionTime, int timeLapsed)
    {
        var timeTracker = new TimeTracker();
        timeTracker.StartTimer();
        Thread.Sleep(executionTime);
        timeTracker.StopTimer();

        Assert.Equal(timeLapsed, timeTracker.Time);
    }
}
