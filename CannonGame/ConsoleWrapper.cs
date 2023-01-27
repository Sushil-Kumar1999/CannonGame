namespace CannonGame;

public class ConsoleWrapper : IConsoleWrapper
{
    public string Read()
    {
        return Console.ReadLine() ?? string.Empty;
    }

    public void Write(string text)
    {
        Console.WriteLine(text);
    }
}
