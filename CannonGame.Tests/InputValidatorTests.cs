using CannonGame.Exceptions;
using System.ComponentModel.DataAnnotations;
using ValidationException = CannonGame.Exceptions.ValidationException;

namespace CannonGame.Tests;

public class InputValidatorTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(45)]
    [InlineData(90)]
    public void ValidateAngle_DoesNotThrowException_WhenAngleIsValid(int angle)
    {
        IInputValidator validator = new InputValidator();
        var exception = Record.Exception(() => validator.ValidateAngle(angle));
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(91)]
    [InlineData(100)]
    public void ValidateAngle_ThrowsCorrectException_WhenAngleIsNotValid(int angle)
    {
        IInputValidator validator = new InputValidator();
        var exception = Assert.Throws<ValidationException>(() => validator.ValidateAngle(angle));

        Assert.NotNull(exception);
        Assert.Equal(ExceptionMessages.AngleOutOfRangeMessage, exception.Message);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(20)]
    public void ValidateVelocity_DoesNotThrowException_WhenVelocityIsValid(int velocity)
    {
        IInputValidator validator = new InputValidator();
        var exception = Record.Exception(() => validator.ValidateVelocity(velocity));
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(21)]
    public void ValidateVelocity_ThrowsCorrectException_WhenVelocityIsNotValid(int velocity)
    {
        IInputValidator validator = new InputValidator();
        var exception = Assert.Throws<ValidationException>(() => validator.ValidateVelocity(velocity));

        Assert.NotNull(exception);
        Assert.Equal(ExceptionMessages.VelocityOutOfRangeMessage, exception.Message);
    }

}
