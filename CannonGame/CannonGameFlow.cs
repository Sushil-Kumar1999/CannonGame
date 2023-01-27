

namespace CannonGame;

public class CannonGameFlow : ICannonGameFlow
{
    private readonly IConsoleIO _consoleIO;
    private readonly ITargetGenerator _targetGenerator;
    private readonly IShotCalculator _shotCalculator;
    private readonly IShotAttemptCounter _shotAttemptCounter;
    private readonly ITargetJudge _targetJudge;

    public CannonGameFlow(IConsoleIO consoleIO, ITargetGenerator targetGenerator, IShotCalculator shotCalculator,
                          IShotAttemptCounter shotAttemptCounter, ITargetJudge targetJudge)
    {
        _consoleIO = consoleIO;
        _targetGenerator = targetGenerator;
        _shotCalculator = shotCalculator;
        _shotAttemptCounter = shotAttemptCounter;
        _targetJudge = targetJudge;
    }

    public void Run()
    {
        
    }
}
