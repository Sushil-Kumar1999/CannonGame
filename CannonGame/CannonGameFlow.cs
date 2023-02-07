using CannonGame.Entities;
using CannonGame.Interfaces;

namespace CannonGame;

public class CannonGameFlow : ICannonGameFlow
{
    private readonly IConsoleIO _consoleIO;
    private readonly ITargetGenerator _targetGenerator;
    private readonly IShotCalculator _shotCalculator;
    private readonly IShotAttemptCounter _shotAttemptCounter;
    private readonly ITargetJudge _targetJudge;
    private readonly IInputValidator _inputValidator;
    private readonly IMortarTargetJudge _mortarTargetJudge;
    private readonly ITimeTracker _timeTracker;
    private readonly IUserDataService _userDataService;

    public CannonGameFlow(IConsoleIO consoleIO, ITargetGenerator targetGenerator, IShotCalculator shotCalculator,
                          IShotAttemptCounter shotAttemptCounter, ITargetJudge targetJudge, IInputValidator inputValidator,
                          IMortarTargetJudge mortarTargetJudge, ITimeTracker timeTracker, IUserDataService userDataService)
    {
        _consoleIO = consoleIO;
        _targetGenerator = targetGenerator;
        _shotCalculator = shotCalculator;
        _shotAttemptCounter = shotAttemptCounter;
        _targetJudge = targetJudge;
        _inputValidator = inputValidator;
        _mortarTargetJudge = mortarTargetJudge;
        _timeTracker = timeTracker;
        _userDataService = userDataService;
    }

    public void Run()
    {
        Point target = _targetGenerator.GenerateTarget();
        _consoleIO.ShowTarget(target);

        string username =  _consoleIO.GetUsername();
        _timeTracker.StartTimer();

        ShotType shotType = _consoleIO.GetShotType();

        bool shotHitsTarget;
        do
        {
            int angle;
            bool isInputValid;

            do
            {
                angle = _consoleIO.GetAngle();
                isInputValid = _inputValidator.ValidateAngle(angle, shotType);

            } while (!isInputValid);

            int velocity;
            do
            {
                velocity = _consoleIO.GetVelocity();
                isInputValid = _inputValidator.ValidateVelocity(velocity);

            } while (!isInputValid);

            Point shot = _shotCalculator.CalculateShot(angle, velocity);
            _shotAttemptCounter.Increment();
            _consoleIO.ShowShot(shot);

            shotHitsTarget = shotType switch
            {
                ShotType.Shot => _targetJudge.JudgeShotHitsTarget(target, shot),
                ShotType.Mortar => _mortarTargetJudge.JudgeShotHitsTarget(target, shot),
                _ => throw new NotImplementedException()
            };
        }
        while (!shotHitsTarget);

        _timeTracker.StopTimer();
        _consoleIO.DisplayAttempts(_shotAttemptCounter.ShotCount);

        _userDataService.AddUser(new User(username, _shotAttemptCounter.ShotCount, _timeTracker.Time));

        _consoleIO.PrintUsers(_userDataService.GetUsers());
    }
}
