namespace CannonGame.Interfaces;

public interface IShotCalculator
{
    Point CalculateShot(int angle, int velocity);
}
