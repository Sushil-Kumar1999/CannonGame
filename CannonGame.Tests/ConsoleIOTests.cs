using CannonGame.Entities;
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

    [Fact]
    public void GetShotType_GetsUserInputOnFirstAttempt()
    {
        _consoleWrapper.Setup(x => x.Write(It.IsAny<string>()));
        _consoleWrapper.Setup(x => x.Read()).Returns("1");
        IConsoleIO consoleIO = new ConsoleIO(_consoleWrapper.Object);

        ShotType shotType = consoleIO.GetShotType();

        _consoleWrapper.Verify(x => x.Write("Choose shot type. Enter 1 for shot, 2 for mortar: "), Times.Once());
        _consoleWrapper.Verify(x => x.Read(), Times.Once());
        Assert.Equal(ShotType.Shot, shotType);
    }

    [Fact]
    public void GetShotType_LoopsUntilUserInputsValidNumber()
    {
        _consoleWrapper.Setup(x => x.Write(It.IsAny<string>()));
        _consoleWrapper.SetupSequence(x => x.Read())
                .Returns("Hello")
                .Returns("")
                .Returns(string.Empty)
                .Returns(" ")
                .Returns("55hjib")
                .Returns("-1")
                .Returns("3")
                .Returns("2");
        IConsoleIO consoleIO = new ConsoleIO(_consoleWrapper.Object);

        ShotType shotType = consoleIO.GetShotType();

        _consoleWrapper.Verify(x => x.Write("Choose shot type. Enter 1 for shot, 2 for mortar: "), Times.Exactly(8));
        _consoleWrapper.Verify(x => x.Read(), Times.Exactly(8));
        Assert.Equal(ShotType.Mortar, shotType);
    }

    [Fact]
    public void GivenTheConsolePromptsUserForUsername_WhenUserEntersUsername_ThenUsernameIsReturned()
    {
        _consoleWrapper.Setup(x => x.Write(It.IsAny<string>()));
        _consoleWrapper.Setup(x => x.Read()).Returns("TestUser");
        IConsoleIO consoleIO = new ConsoleIO(_consoleWrapper.Object);

        string username = consoleIO.GetUsername();

        Assert.Equal("TestUser", username);
    }

    [Fact]
    public void GivenUsersIsProvided_WhenPrintCalled_UsersArePrintedToConsole()
    {
        IList<User> users = new List<User>
        {
            new User("test1", 12, 100),
            new User("test2", 14, 133),
            new User("test3", 10, 78)
        };
        _consoleWrapper.Setup(x => x.Write(It.IsAny<string>()));
        IConsoleIO consoleIO = new ConsoleIO(_consoleWrapper.Object);

        consoleIO.PrintUsers(users);

        var usersArray = users.ToArray();
        _consoleWrapper.Verify(x => x.Write(usersArray[0].ToString()), Times.Exactly(1));
        _consoleWrapper.Verify(x => x.Write(usersArray[1].ToString()), Times.Exactly(1));
        _consoleWrapper.Verify(x => x.Write(usersArray[2].ToString()), Times.Exactly(1));
    }

}
