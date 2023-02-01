using CannonGame.Interfaces;
using System.Runtime.ConstrainedExecution;

namespace CannonGame;

public class MortarTargetJudge : TargetJudge, IMortarTargetJudge
{
    private const int mortarHitRadius = 1;

    public override bool JudgeShotHitsTarget(Point target, Point shot)
    {
        return (shot.X == target.X + mortarHitRadius || shot.X == target.X - mortarHitRadius || shot.X == target.X) &&
               (shot.Y == target.Y + mortarHitRadius || shot.Y == target.Y - mortarHitRadius || shot.Y == target.Y);
    }
}
