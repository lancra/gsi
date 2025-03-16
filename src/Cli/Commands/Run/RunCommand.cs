using System.CommandLine;

namespace GitStatusInteractive.Cli.Commands.Run;

internal sealed class RunCommand : Command<RunCommandOptions, RunCommandOptionsHandler>
{
    public RunCommand()
        : base("run", "Runs an interactive status execution.")
    {
        AddAlias("r");
        AddArgument(
            new Argument<string>(
                "pathspec",
                getDefaultValue: () => ".",
                description: "The pattern used to limit paths in Git commands."));
    }
}
