using CannonGame.Interfaces;

namespace CannonGame;

public class TargetJudge : ITargetJudge
{
    public bool JudgeShotHitsTarget(Point target, Point shot)
    {
        return target.Equals(shot);
    }
}
