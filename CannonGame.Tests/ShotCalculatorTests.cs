using CannonGame.Interfaces;

namespace CannonGame.Tests;

public class ShotCalculatorTests
{

    [Fact]
    public void CalculateShot_ReturnsNotNullShot()
    {
        IShotCalculator shotCalculator= new ShotCalculator();
        Point shot = shotCalculator.CalculateShot(45, 15);
        Assert.NotNull(shot);
    }

    [Theory]
    [InlineData(30, 5, 4, 3)]
    [InlineData(90, 20, 0, 20)]
    public void CalculateShot_CalulatesShotCorrectly(int angle, int velocity, int expectedX, int expectedY)
    {
        IShotCalculator shotCalculator = new ShotCalculator();

        Point shot = shotCalculator.CalculateShot(angle, velocity);

        Assert.Equal(expectedX, shot.X);
        Assert.Equal(expectedY, shot.Y);
    }





    //[Fact]
    //public void GenerateTarget_ValidatesAngle()
    //{
    //    // Arrange
    //    _inputValidator.Setup(x => x.ValidateAngle(It.IsAny<int>()));
    //    _inputValidator.Setup(x => x.ValidateVelocity(It.IsAny<int>()));
    //    ITargetGenerator targetGenerator = new TargetGenerator(_inputValidator.Object);

    //    // act
    //    targetGenerator.GenerateTarget(5, 20);

    //    // assert
    //    _inputValidator.Verify(x => x.ValidateAngle(It.Is<int>(x => x == 5)), Times.Once);
    //}

    //[Fact]
    //public void GenerateTarget_ValidatesVelocity()
    //{
    //    // arrange
    //    _inputValidator.Setup(x => x.ValidateAngle(It.IsAny<int>()));
    //    _inputValidator.Setup(x => x.ValidateVelocity(It.IsAny<int>()));
    //    ITargetGenerator targetGenerator = new TargetGenerator(_inputValidator.Object);

    //    // act
    //    targetGenerator.GenerateTarget(5, 20);

    //    // assert
    //    _inputValidator.Verify(x => x.ValidateVelocity(It.Is<int>(x => x == 20)), Times.Once);
    //}
}
