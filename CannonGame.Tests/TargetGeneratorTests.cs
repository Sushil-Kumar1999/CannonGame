namespace CannonGame.Tests;

public class TargetGeneratorTests
{
    [Fact]
    public void GenerateTarget_ReturnsValidTarget()
    {
        ITargetGenerator targetGenerator = new TargetGenerator();

        for (int i = 0; i < 100; i++)
        {
            Point target = targetGenerator.GenerateTarget();

            Assert.NotNull(target);
            Assert.True(target.X > 0 && target.X <= 10);
            Assert.True(target.Y > 0 && target.Y <= 10);
        }
    }
}
