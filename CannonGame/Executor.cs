using CannonGame.Entities;
using CannonGame.Interfaces;
using CannonGame.Services;

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

        //r service = new UserDataService(new JsonFileIO());
       // _s.GetUsers().ToList().ForEach(x => { Console.WriteLine(x.Username + x.Score); });
        //_s.AddUser(new User("G", 9, 9));
        //_s.GetUsers().ToList().ForEach(x => { Console.WriteLine(x.Username + x.Score); });
    }
}
