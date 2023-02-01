using CannonGame.Interfaces;

namespace CannonGame.Tests;

public class TargetJudgeTests
{
    [Fact]
    public void JudgeShotHitsTarget_ReturnsTrue_WhenShotAndTarget_AreSame()
    {
        Point target = new Point(5, 5);
        Point shot = new Point(5, 5);
        ITargetJudge targetJudge = new TargetJudge();

        bool result = targetJudge.JudgeShotHitsTarget(target, shot);
        Assert.True(result);
    }

    [Fact]
    public void JudgeShotHitsTarget_ReturnsFalse_WhenShotAndTarget_AreNotSame()
    {
        Point target = new Point(7, 8);
        Point shot = new Point(2, 3);
        ITargetJudge targetJudge = new TargetJudge();

        bool result = targetJudge.JudgeShotHitsTarget(target, shot);
        Assert.False(result);
    }
}
