namespace GitStatusInteractive.Core;

internal record GitCommandResult(bool Succeeded, int ExitCode, string Output)
{
    public GitCommandResult(int exitCode, string output)
        : this(exitCode == 0, exitCode, output)
    {
    }
}
