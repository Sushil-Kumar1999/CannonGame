namespace CannonGame.Tests;

public class ConsoleWrapperTests
{
    [Fact]
    public void Read_ReadsFromConsole()
    {
        string input = "Hello World";
        var stringReader = new StringReader(input);
        Console.SetIn(stringReader);

        IConsoleWrapper console = new ConsoleWrapper();
        string result = console.Read();

        Assert.Equal(input, result);
    }

    [Fact]
    public void Write_WritesToConsole()
    {
        string expectedOutput = "Hello World";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        IConsoleWrapper console = new ConsoleWrapper();
        console.Write(expectedOutput);

        string actualOutput = stringWriter.ToString().TrimEnd(new char[] { '\r', '\n' });

        Assert.Equal(expectedOutput, actualOutput);
    }
}
