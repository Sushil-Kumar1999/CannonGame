using CannonGame.Interfaces;
using Moq;

namespace CannonGame.Tests;

public class ConsoleIOTests
{
    private readonly Mock<IConsoleWrapper> _consoleWrapper;

    public ConsoleIOTests()
    {
        _consoleWrapper = new Mock<IConsoleWrapper>();
    }

    [Fact]
    public void GetAngle_GetsUserInputOnFirstAttempt()
    {
        _consoleWrapper.Setup(x => x.Write(It.IsAny<string>()));
        _consoleWrapper.Setup(x => x.Read()).Returns("5");
        IConsoleIO consoleIO = new ConsoleIO(_consoleWrapper.Object);
        int actualOuput = consoleIO.GetAngle();

        _consoleWrapper.Verify(x => x.Write("Please enter an angle between 1 and 90: "), Times.Once());
        _consoleWrapper.Verify(x => x.Read(), Times.Once());
        Assert.Equal(5, actualOuput);
    }

    [Fact]
    public void GetAngle_LoopsUntilUserInputsValidNumber()
    {
        _consoleWrapper.Setup(x => x.Write(It.IsAny<string>()));
        _consoleWrapper.SetupSequence(x => x.Read())
                .Returns("Hello")
                .Returns("")
                .Returns(string.Empty)
                .Returns(" ")
                .Returns("55hjib")
                .Returns("5");

        IConsoleIO consoleIO = new ConsoleIO(_consoleWrapper.Object);
        int actualOuput = consoleIO.GetAngle();

        _consoleWrapper.Verify(x => x.Write("Please enter an angle between 1 and 90: "), Times.Exactly(6));
        _consoleWrapper.Verify(x => x.Read(), Times.Exactly(6));
        Assert.Equal(5, actualOuput);
    }

    [Fact]
    public void GetVelocity_GetsUserInputOnFirstAttempt()
    {
        _consoleWrapper.Setup(x => x.Write(It.IsAny<string>()));
        _consoleWrapper.Setup(x => x.Read()).Returns("5");
        IConsoleIO consoleIO = new ConsoleIO(_consoleWrapper.Object);
        int velocity = consoleIO.GetVelocity();

        _consoleWrapper.Verify(x => x.Write("Please enter a velocity between 1 and 20: "), Times.Once());
        _consoleWrapper.Verify(x => x.Read(), Times.Once());
        Assert.Equal(5, velocity);
    }

    [Fact]
    public void GetVelocity_LoopsUntilUserInputsValidNumber()
    {
        _consoleWrapper.Setup(x => x.Write(It.IsAny<string>()));
        _consoleWrapper.SetupSequence(x => x.Read())
                .Returns("Hello")
                .Returns("")
                .Returns(string.Empty)
                .Returns(" ")
                .Returns("55hjib")
                .Returns("5");

        IConsoleIO consoleIO = new ConsoleIO(_consoleWrapper.Object);
        int velocity = consoleIO.GetVelocity();

        _consoleWrapper.Verify(x => x.Write("Please enter a velocity between 1 and 20: "), Times.Exactly(6));
        _consoleWrapper.Verify(x => x.Read(), Times.Exactly(6));
        Assert.Equal(5, velocity);
    }

    [Fact]
    public void DisplayAttempts_WritesToConsole()
    {
        _consoleWrapper.Setup(x => x.Write(It.IsAny<string>()));
        IConsoleIO consoleIO = new ConsoleIO(_consoleWrapper.Object);

        consoleIO.DisplayAttempts(5);

        _consoleWrapper.Verify(x => x.Write("Your shot hit the target. You took 5 attempts"));
    }

    [Fact]
    public void ShowTarget_WritesToConsole()
    {
        _consoleWrapper.Setup(x => x.Write(It.IsAny<string>()));
        IConsoleIO consoleIO = new ConsoleIO(_consoleWrapper.Object);

        consoleIO.ShowTarget(new Point(4, 7));

        _consoleWrapper.Verify(x => x.Write("Target is X: 4 and Y: 7"));
    }

    [Fact]
    public void ShowShot_WritesToConsole()
    {
        _consoleWrapper.Setup(x => x.Write(It.IsAny<string>()));
        IConsoleIO consoleIO = new ConsoleIO(_consoleWrapper.Object);

        consoleIO.ShowShot(new Point(4, 7));

        _consoleWrapper.Verify(x => x.Write($"Shot landed at X: 4 and Y: 7"));
    }
}
