using System.CommandLine;
using GitStatusInteractive.Cli.Commands.Run;

namespace GitStatusInteractive.Cli.Commands;

internal sealed class GitStatusInteractiveRootCommand : RootCommand
{
    public GitStatusInteractiveRootCommand()
        : base("Interactively manage changes from the current Git status.")
        => AddCommand(new RunCommand());
}
