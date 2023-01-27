using Moq;

namespace CannonGame.Tests;

public class CannonGameFlowTests
{
    private readonly Mock<IConsoleIO> _consoleIO;
    private readonly Mock<ITargetGenerator> _targetGenerator;
    private readonly Mock<IShotCalculator> _shotCalculator;
    private readonly Mock<IShotAttemptCounter> _shotAttemptCounter;
    private readonly Mock<ITargetJudge> _targetJudge;

    public CannonGameFlowTests()
    {
        _consoleIO = new Mock<IConsoleIO>();
        _targetGenerator = new Mock<ITargetGenerator>();
        _shotCalculator = new Mock<IShotCalculator>();
        _shotAttemptCounter = new Mock<IShotAttemptCounter>();
        _targetJudge = new Mock<ITargetJudge>();
    }

    [Fact]
    public void Run_RunsFlow()
    {
        // Arrange
        _consoleIO.Setup(x => x.GetAngle()).Returns(20);
        _consoleIO.Setup(x => x.GetVelocity()).Returns(7);

        // Act
        ICannonGameFlow flow = new CannonGameFlow(_consoleIO.Object, _targetGenerator.Object, _shotCalculator.Object,
                                                _shotAttemptCounter.Object, _targetJudge.Object);
        flow.Run();

        // Assert
        _consoleIO.Verify(x => x.GetAngle(), Times.Once);
        _consoleIO.Verify(x => x.GetVelocity(), Times.Once);
    }
}
