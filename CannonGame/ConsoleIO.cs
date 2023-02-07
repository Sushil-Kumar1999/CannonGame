using CannonGame.Entities;
using CannonGame.Interfaces;

namespace CannonGame;

public class ConsoleIO : IConsoleIO
{
    private readonly IConsoleWrapper _console;

    public ConsoleIO(IConsoleWrapper console)
    {
        _console = console;
    }

    public int GetAngle()
    {
        string input = string.Empty;
        do
        {
            _console.Write("Please enter an angle between 1 and 90: ");
            input = _console.Read();
        }
        while (!int.TryParse(input, out _));
    
        return int.Parse(input);
    }

    public int GetVelocity()
    {

        string input = string.Empty;
        do
        {
            _console.Write("Please enter a velocity between 1 and 20: ");
            input = _console.Read();
        }
        while (!int.TryParse(input, out _));

        return int.Parse(input);
    }

    public void ShowShot(Point shot)
    {
        _console.Write($"Shot landed at X: {shot.X} and Y: {shot.Y}");
    }

    public void DisplayAttempts(int attemptCount)
    {
        _console.Write($"Your shot hit the target. You took {attemptCount} attempts");
    }

    public void ShowTarget(Point target)
    {
        _console.Write($"Target is X: {target.X} and Y: {target.Y}");
    }

    public ShotType GetShotType()
    {
        string input = string.Empty;
        bool isInt = false;
        int num = 0;
        do
        {
            _console.Write("Choose shot type. Enter 1 for shot, 2 for mortar: ");
            input = _console.Read();
            isInt = int.TryParse(input, out num);
        }
        while (!isInt || !Enum.IsDefined(typeof(ShotType), num));

        return (ShotType)num;
    }

    public string GetUsername()
    {
        _console.Write("Please enter your username: ");
        return _console.Read();
    }

    public void PrintUsers(IEnumerable<User> users)
    {
        foreach(User user in users)
        {
            _console.Write(user.ToString());
        }
    }
}
