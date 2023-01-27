namespace CannonGame;

public interface IShotAttemptCounter
{
    public int ShotCount { get; }
    void Increment();
}