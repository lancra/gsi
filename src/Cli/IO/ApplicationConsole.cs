using Spectre.Console;

namespace GitStatusInteractive.Cli.IO;

internal sealed class ApplicationConsole(IAnsiConsole output, IAnsiConsole error) : IApplicationConsole
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

    public static IApplicationConsole Console => _console.Value;

    public IAnsiConsole Output { get; } = output;

    public IAnsiConsole Error { get; } = error;
}
