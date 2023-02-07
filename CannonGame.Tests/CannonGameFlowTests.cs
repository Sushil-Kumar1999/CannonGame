using CannonGame.Interfaces;
using Moq;

namespace CannonGame.Tests;

public class CannonGameFlowTests
{
    private readonly Mock<IConsoleIO> _consoleIO;
    private readonly Mock<ITargetGenerator> _targetGenerator;
    private readonly Mock<IShotCalculator> _shotCalculator;
    private readonly Mock<IShotAttemptCounter> _shotAttemptCounter;
    private readonly Mock<ITargetJudge> _targetJudge;
    private readonly Mock<IInputValidator> _inputValidator;
    private readonly Mock<IMortarTargetJudge> _mortarTargetJudge;
    private readonly Mock<ITimeTracker> _timeTracker;
    private readonly Mock<IUserDataService> _userDataService;

    public CannonGameFlowTests()
    {
        _consoleIO = new Mock<IConsoleIO>();
        _targetGenerator = new Mock<ITargetGenerator>();
        _shotCalculator = new Mock<IShotCalculator>();
        _shotAttemptCounter = new Mock<IShotAttemptCounter>();
        _targetJudge = new Mock<ITargetJudge>();
        _inputValidator = new Mock<IInputValidator>();
        _mortarTargetJudge = new Mock<IMortarTargetJudge>();
        _timeTracker = new Mock<ITimeTracker>();
        _userDataService = new Mock<IUserDataService>();
    }

    [Fact]
    public void Run_RunsFlow_ForShot()
    {
        // Arrange
        Point testTarget = new Point(5, 8);
        _targetGenerator.Setup(x => x.GenerateTarget()).Returns(testTarget);
        _consoleIO.Setup(x => x.ShowTarget(It.Is<Point>(p => p.X == testTarget.X && p.Y == testTarget.Y)));
        _consoleIO.Setup(x => x.GetShotType()).Returns(ShotType.Shot);

        int angle = 20;
        _consoleIO.Setup(x => x.GetAngle()).Returns(angle);
        _inputValidator.Setup(x => x.ValidateAngle(angle, ShotType.Shot)).Returns(true);
        int velocity = 10;
        _consoleIO.Setup(x => x.GetVelocity()).Returns(velocity);
        _inputValidator.Setup(x => x.ValidateVelocity(velocity)).Returns(true);
        Point testShot = new Point(5, 8);
        _shotCalculator.Setup(x => x.CalculateShot(It.IsAny<int>(), It.IsAny<int>())).Returns(testShot);
        _shotAttemptCounter.Setup(x => x.Increment());
        _consoleIO.Setup(x => x.ShowShot(It.Is<Point>(p => p.X == testShot.X && p.Y == testShot.Y)));
        _targetJudge.Setup(x => x.JudgeShotHitsTarget(testTarget, testShot)).Returns(true);
        int testShotCount = 12;
        _shotAttemptCounter.Setup(x => x.ShotCount).Returns(testShotCount);
        _consoleIO.Setup(x => x.DisplayAttempts(It.Is<int>(x => x == testShotCount)));

        // Act
        ICannonGameFlow flow = new CannonGameFlow(_consoleIO.Object, _targetGenerator.Object, _shotCalculator.Object,
                                                _shotAttemptCounter.Object, _targetJudge.Object, _inputValidator.Object,
                                                _mortarTargetJudge.Object, _timeTracker.Object, _userDataService.Object);
        flow.Run();

        // Assert
        _targetGenerator.Verify(x => x.GenerateTarget(), Times.Once);
        _consoleIO.Verify(x => x.ShowTarget(testTarget), Times.Once);
        _consoleIO.Verify(x => x.GetShotType(), Times.Once);
        _consoleIO.Verify(x => x.GetAngle(), Times.Once);
        _inputValidator.Verify(x => x.ValidateAngle(angle, ShotType.Shot), Times.Once);
        _consoleIO.Verify(x => x.GetVelocity(), Times.Once);
        _inputValidator.Verify(x => x.ValidateVelocity(velocity), Times.Once);
        _shotCalculator.Verify(x => x.CalculateShot(angle, velocity), Times.Once);
        _shotAttemptCounter.Verify(x => x.Increment(), Times.Once);
        _consoleIO.Verify(x => x.ShowShot(testShot), Times.Once);
        _targetJudge.Verify(x => x.JudgeShotHitsTarget(testTarget, testShot), Times.Once);
        _consoleIO.Verify(x => x.DisplayAttempts(It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public void Run_RunsFlow_ForMortar()
    {
        // Arrange
        Point testTarget = new Point(5, 8);
        _targetGenerator.Setup(x => x.GenerateTarget()).Returns(testTarget);
        _consoleIO.Setup(x => x.ShowTarget(It.Is<Point>(p => p.X == testTarget.X && p.Y == testTarget.Y)));
        _consoleIO.Setup(x => x.GetShotType()).Returns(ShotType.Mortar);

        int angle = 20;
        _consoleIO.Setup(x => x.GetAngle()).Returns(angle);
        _inputValidator.Setup(x => x.ValidateAngle(angle, ShotType.Mortar)).Returns(true);
        int velocity = 10;
        _consoleIO.Setup(x => x.GetVelocity()).Returns(velocity);
        _inputValidator.Setup(x => x.ValidateVelocity(velocity)).Returns(true);
        Point testShot = new Point(5, 8);
        _shotCalculator.Setup(x => x.CalculateShot(It.IsAny<int>(), It.IsAny<int>())).Returns(testShot);
        _shotAttemptCounter.Setup(x => x.Increment());
        _consoleIO.Setup(x => x.ShowShot(It.Is<Point>(p => p.X == testShot.X && p.Y == testShot.Y)));
        _mortarTargetJudge.Setup(x => x.JudgeShotHitsTarget(testTarget, testShot)).Returns(true);
        int testShotCount = 12;
        _shotAttemptCounter.Setup(x => x.ShotCount).Returns(testShotCount);
        _consoleIO.Setup(x => x.DisplayAttempts(It.Is<int>(x => x == testShotCount)));

        // Act
        ICannonGameFlow flow = new CannonGameFlow(_consoleIO.Object, _targetGenerator.Object, _shotCalculator.Object,
                                                _shotAttemptCounter.Object, _targetJudge.Object, _inputValidator.Object,
                                                _mortarTargetJudge.Object, _timeTracker.Object, _userDataService.Object);
        flow.Run();

        // Assert
        _targetGenerator.Verify(x => x.GenerateTarget(), Times.Once);
        _consoleIO.Verify(x => x.ShowTarget(testTarget), Times.Once);
        _consoleIO.Verify(x => x.GetShotType(), Times.Once);
        _consoleIO.Verify(x => x.GetAngle(), Times.Once);
        _inputValidator.Verify(x => x.ValidateAngle(angle, ShotType.Mortar), Times.Once);
        _consoleIO.Verify(x => x.GetVelocity(), Times.Once);
        _inputValidator.Verify(x => x.ValidateVelocity(velocity), Times.Once);
        _shotCalculator.Verify(x => x.CalculateShot(angle, velocity), Times.Once);
        _shotAttemptCounter.Verify(x => x.Increment(), Times.Once);
        _consoleIO.Verify(x => x.ShowShot(testShot), Times.Once);
        _mortarTargetJudge.Verify(x => x.JudgeShotHitsTarget(testTarget, testShot), Times.Once);
        _consoleIO.Verify(x => x.DisplayAttempts(It.IsAny<int>()), Times.Once);
    }
}
