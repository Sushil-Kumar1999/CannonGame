using CannonGame.Interfaces;
using CannonGame.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO.Abstractions;

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
        services.AddScoped<IMortarTargetJudge, MortarTargetJudge>();
        services.AddScoped<IUserDataService, UserDataService>();
        services.AddScoped<IJsonFileIO, JsonFileIO>();
        services.AddScoped<IFileSystem, FileSystem>();
        services.AddScoped<ITimeTracker, TimeTracker>();
    }
}
