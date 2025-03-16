using GitStatusInteractive.Core;
using Spectre.Console;

namespace GitStatusInteractive.Cli.IO;

internal sealed class ApplicationConsolePrinter(IApplicationConsole console) : IPrinter
{
    private readonly IApplicationConsole _console = console;

    public void PrintChanges(ChangeGroup changes)
    {
        foreach (var file in changes.Files)
        {
            foreach (var areaIndicator in file.Indicators.OrderBy(indicator => indicator.Area.Order))
            {
                areaIndicator.Indicator.ColorOverrides.TryGetValue(areaIndicator.Area, out var overrideColor);
                var color = overrideColor ?? areaIndicator.Area.Color;

                _console.Output.Write(
                    new Markup($"[{color.Name.ToLower()}]{areaIndicator.Indicator.Value}[/]"));
            }

            _console.Output.WriteLine($" {file.Path}");
        }
    }

    public void PrintLine(string value) => _console.Output.WriteLine(value);
}
