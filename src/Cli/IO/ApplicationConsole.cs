using Spectre.Console;

namespace GitStatusInteractive.Cli.IO;

internal sealed class ApplicationConsole : IApplicationConsole
{
    private static readonly Lazy<IApplicationConsole> _console = new(
        () => new ApplicationConsole(
            AnsiConsole.Create(
                new()
                {
                    Ansi = AnsiSupport.Detect,
                    ColorSystem = ColorSystemSupport.Detect,
                    Out = new AnsiConsoleOutput(System.Console.Out),
                }),
            AnsiConsole.Create(
                new()
                {
                    Ansi = AnsiSupport.Detect,
                    ColorSystem = ColorSystemSupport.Detect,
                    Out = new AnsiConsoleOutput(System.Console.Error),
                })));

    public ApplicationConsole(IAnsiConsole output, IAnsiConsole error)
    {
        Output = output;
        Error = error;
    }

    public static IApplicationConsole Console => _console.Value;

    public IAnsiConsole Output { get; }

    public IAnsiConsole Error { get; }
}
