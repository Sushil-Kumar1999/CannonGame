using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CannonGame.Registrations;

namespace CannonGame;

public class Program
{
    public static void Main(string[] args)
    {
        Host.CreateDefaultBuilder()
            .ConfigureServices(services => services.AddSingleton<IExecutor, Executor>())
            .ConfigureServices(ContainerBuilder.RegisterServices)
            .Build()
            .Services.GetService<IExecutor>()!
            .Execute();
    }
}