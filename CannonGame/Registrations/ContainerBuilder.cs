using CannonGame.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CannonGame.Registrations;

public static class ContainerBuilder
{
    public static void RegisterServices(HostBuilderContext hostContext, IServiceCollection services)
    {
        services.AddScoped<IShotAttemptCounter, ShotAttemptCounter>();
        services.AddScoped<IShotCalculator, ShotCalculator>();
        services.AddScoped<IConsoleIO, ConsoleIO>();
        services.AddScoped<ITargetGenerator, TargetGenerator>();
        services.AddScoped<ITargetJudge, TargetJudge>();
        services.AddScoped<IInputValidator, InputValidator>();
        services.AddScoped<IConsoleWrapper, ConsoleWrapper>();
        services.AddScoped<ICannonGameFlow, CannonGameFlow>();
    }
}
