using CannonGame.Interfaces;

namespace CannonGame.Tests;

public class MortarTargetJudgeTests
{
    [Fact]
    public void JudgeShotHitsTarget_ReturnsTrue_WhenMortarHitsTarget()
    {
        Point target = new Point(5, 5);
        Point shot = new Point(5, 5);
        IMortarTargetJudge targetJudge = new MortarTargetJudge();

        bool result = targetJudge.JudgeShotHitsTarget(target, shot);
        Assert.True(result);
    }

    [Theory]
    [InlineData(4, 5)]
    [InlineData(6, 5)]
    [InlineData(5, 4)]
    [InlineData(5, 6)]
    [InlineData(4, 4)]
    [InlineData(6, 6)]
    public void JudgeShotHitsTarget_ReturnsFalse_WhenTarget_InsideMortarRadius(int x, int y)
    {
        Point target = new Point(5, 5);
        Point shot = new Point(x, y);
        IMortarTargetJudge targetJudge = new MortarTargetJudge();

        bool result = targetJudge.JudgeShotHitsTarget(target, shot);
        Assert.True(result);
    }

    [Theory]
    [InlineData(3, 5)]
    [InlineData(7, 5)]
    [InlineData(5, 3)]
    [InlineData(5, 7)]
    [InlineData(3, 3)]
    [InlineData(7, 7)]
    public void JudgeShotHitsTarget_ReturnsTrue_WhenTarget_OutsideMortarRadius(int x, int y)
    {
        Point target = new Point(5, 5);
        Point shot = new Point(x, y);
        IMortarTargetJudge targetJudge = new MortarTargetJudge();

        bool result = targetJudge.JudgeShotHitsTarget(target, shot);
        Assert.False(result);
    }

}
