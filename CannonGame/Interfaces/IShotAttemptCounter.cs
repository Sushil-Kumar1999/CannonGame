namespace CannonGame.Interfaces;

public interface IShotAttemptCounter
{
    public int ShotCount { get; }
    void Increment();
}