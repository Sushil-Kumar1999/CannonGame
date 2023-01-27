namespace CannonGame;

public class TargetJudge : ITargetJudge
{
    public bool JudgeShotHitsTarget(Point target, Point shot)
    {
        return shot.X == target.X && shot.Y == target.Y;
    }
}
