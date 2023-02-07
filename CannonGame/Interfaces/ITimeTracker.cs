namespace CannonGame.Interfaces;

public interface ITimeTracker
{
    int Time { get; }

    void StartTimer();
    void StopTimer();
}
