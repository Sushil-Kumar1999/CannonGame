using Moq;

namespace CannonGame.Tests;

public class ExecutorTests
{
    [Fact]
    public void Execute_Invokes_CannonGameFlow()
    {
        Mock<ICannonGameFlow> _cannonGameFlow = new Mock<ICannonGameFlow>(MockBehavior.Loose);
        IExecutor executor = new Executor(_cannonGameFlow.Object);

        executor.Execute();

        _cannonGameFlow.Verify(x => x.Run(), Times.Once);
    }
}
