using CannonGame.Interfaces;

namespace CannonGame.Tests;

public class InputValidatorTests
{
    [Theory]
    [InlineData(1, ShotType.Shot)]
    [InlineData(45, ShotType.Shot)]
    [InlineData(90, ShotType.Shot)]
    [InlineData(15, ShotType.Mortar)]
    [InlineData(25, ShotType.Mortar)]
    public void ValidateAngle_ReturnsTrue_WhenAngleIsValid(int angle, ShotType shotType)
    {
        IInputValidator validator = new InputValidator();
        bool isValid = validator.ValidateAngle(angle, shotType);
        Assert.True(isValid);
    }

    [Theory]
    [InlineData(-1, ShotType.Shot)]
    [InlineData(0, ShotType.Shot)]
    [InlineData(91, ShotType.Shot)]
    [InlineData(100, ShotType.Shot)]
    [InlineData(-1, ShotType.Mortar)]
    [InlineData(0, ShotType.Mortar)]
    [InlineData(91, ShotType.Mortar)]
    [InlineData(100, ShotType.Mortar)]
    [InlineData(89, ShotType.Mortar)]
    [InlineData(2, ShotType.Mortar)]
    public void ValidateAngle_ReturnsFalse_WhenAngleIsNotValid(int angle, ShotType shotType)
    {
        IInputValidator validator = new InputValidator();
        bool isValid = validator.ValidateAngle(angle, shotType);
        Assert.False(isValid);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(20)]
    public void ValidateVelocity_ReturnsTrue_WhenAngleIsValid(int velocity)
    {
        IInputValidator validator = new InputValidator();
        bool isValid = validator.ValidateVelocity(velocity);
        Assert.True(isValid);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(21)]
    public void ValidateVelocity_ReturnsFalse_WhenAngleIsNotValid(int velocity)
    {
        IInputValidator validator = new InputValidator();
        bool isValid = validator.ValidateVelocity(velocity);
        Assert.False(isValid);
    }

    //[Theory]
    //[InlineData(1)]
    //[InlineData(45)]
    //[InlineData(90)]
    //public void ValidateAngle_DoesNotThrowException_WhenAngleIsValid(int angle)
    //{
    //    IInputValidator validator = new InputValidator();
    //    var exception = Record.Exception(() => validator.ValidateAngle(angle));
    //    Assert.Null(exception);
    //}

    //[Theory]
    //[InlineData(-1)]
    //[InlineData(0)]
    //[InlineData(91)]
    //[InlineData(100)]
    //public void ValidateAngle_ThrowsCorrectException_WhenAngleIsNotValid(int angle)
    //{
    //    IInputValidator validator = new InputValidator();
    //    var exception = Assert.Throws<ValidationException>(() => validator.ValidateAngle(angle));

    //    Assert.NotNull(exception);
    //    Assert.Equal(ExceptionMessages.AngleOutOfRangeMessage, exception.Message);
    //}

    //[Theory]
    //[InlineData(1)]
    //[InlineData(10)]
    //[InlineData(20)]
    //public void ValidateVelocity_DoesNotThrowException_WhenVelocityIsValid(int velocity)
    //{
    //    IInputValidator validator = new InputValidator();
    //    var exception = Record.Exception(() => validator.ValidateVelocity(velocity));
    //    Assert.Null(exception);
    //}

    //[Theory]
    //[InlineData(-1)]
    //[InlineData(0)]
    //[InlineData(21)]
    //public void ValidateVelocity_ThrowsCorrectException_WhenVelocityIsNotValid(int velocity)
    //{
    //    IInputValidator validator = new InputValidator();
    //    var exception = Assert.Throws<ValidationException>(() => validator.ValidateVelocity(velocity));

    //    Assert.NotNull(exception);
    //    Assert.Equal(ExceptionMessages.VelocityOutOfRangeMessage, exception.Message);
    //}

}
