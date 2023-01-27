namespace CannonGame;

public class ShotCalculator : IShotCalculator
{
    public Point CalculateShot(int angle, int velocity)
    {
        float degrees = (float) (angle * (Math.PI / 180));

        float x = (float) Math.Cos(degrees) * velocity;
        float y = (float) Math.Sin(degrees) * velocity;

        int roundedX = (int)Math.Round(x, MidpointRounding.AwayFromZero);
        int roundedY = (int)Math.Round(y, MidpointRounding.AwayFromZero);

        return new Point(roundedX, roundedY);
    }
}
