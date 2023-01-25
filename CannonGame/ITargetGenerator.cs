namespace CannonGame;

public interface ITargetGenerator
{
    Point GenerateTarget(int angle, int velocity);
}
