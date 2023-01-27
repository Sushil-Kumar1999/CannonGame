namespace CannonGame;

public class Executor : IExecutor
{
    private readonly ICannonGameFlow _cannonGameFlow;

    public Executor(ICannonGameFlow cannonGameFlow)
    {
        _cannonGameFlow = cannonGameFlow;
    }

    public void Execute()
    {
        _cannonGameFlow.Run();
    }
}
