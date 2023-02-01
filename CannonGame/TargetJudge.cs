using CannonGame.Interfaces;

namespace CannonGame;

public class TargetJudge : ITargetJudge
{
    public virtual bool JudgeShotHitsTarget(Point target, Point shot)
    {
        return target.Equals(shot);
    }
}
