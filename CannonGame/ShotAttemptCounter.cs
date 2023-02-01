using CannonGame.Interfaces;

namespace CannonGame;

public class ShotAttemptCounter : IShotAttemptCounter
{
	public int ShotCount { get; private set; }

	public ShotAttemptCounter()
	{
		ShotCount = 0;
	}

	public void Increment()
	{
		ShotCount++;
	}
}
