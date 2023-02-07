using CannonGame.Interfaces;
using System.Diagnostics;

namespace CannonGame;

public class TimeTracker : ITimeTracker
{
    public int Time { private set; get; }
    private Stopwatch stopwatch;
 
    public TimeTracker()
    {
        stopwatch = new Stopwatch();
    }

    public void StartTimer()
    {
        stopwatch.Start();
    }

    public void StopTimer()
    {
        stopwatch.Stop();
        Time = (int)stopwatch.ElapsedMilliseconds / 1000;
    }
}
