using Moq;

namespace CannonGame.Tests;

public class TargetGeneratorTests
{
    private readonly Mock<IInputValidator> _inputValidator;

    public TargetGeneratorTests()
    {
        _inputValidator = new Mock<IInputValidator>(MockBehavior.Strict);
    }

    [Fact]
    public void GenerateTarget_ValidatesAngle()
    {
        // Arrange
        _inputValidator.Setup(x => x.ValidateAngle(It.IsAny<int>()));
        _inputValidator.Setup(x => x.ValidateVelocity(It.IsAny<int>()));
        ITargetGenerator targetGenerator = new TargetGenerator(_inputValidator.Object);

        // act
        targetGenerator.GenerateTarget(5, 20);

        // assert
        _inputValidator.Verify(x => x.ValidateAngle(It.Is<int>(x => x == 5)), Times.Once);
    }

    [Fact]
    public void GenerateTarget_ValidatesVelocity()
    {
        // arrange
        _inputValidator.Setup(x => x.ValidateAngle(It.IsAny<int>()));
        _inputValidator.Setup(x => x.ValidateVelocity(It.IsAny<int>()));
        ITargetGenerator targetGenerator = new TargetGenerator(_inputValidator.Object);

        // act
        targetGenerator.GenerateTarget(5, 20);

        // assert
        _inputValidator.Verify(x => x.ValidateVelocity(It.Is<int>(x => x == 20)), Times.Once);
    }
}
