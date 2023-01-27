namespace CannonGame.Tests;

public class ShotAttemptCounterTests
{

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(10)]
    public void ShotCount_IncrementsByN_WhenIncrementIsCalled_N_Times(int n)
    {
        IShotAttemptCounter shotAttemptCounter = new ShotAttemptCounter();

        for (int i = 0; i < n; i++)
        {
            shotAttemptCounter.Increment();
        }
       
        Assert.Equal(n, shotAttemptCounter.ShotCount);
    }
}
