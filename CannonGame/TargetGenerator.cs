using CannonGame.Interfaces;

namespace CannonGame;

public class TargetGenerator : ITargetGenerator
{
    private readonly Random _random;

    public TargetGenerator()
    {
        _random = new Random(1);
    }

    public Point GenerateTarget()
    {
        int abscissa = 1 + _random.Next(10); // between 1 to 10 inclusive
        int ordinate = 1 + _random.Next(10);

        return new Point(abscissa, ordinate);
    }
}
