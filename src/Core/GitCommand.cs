using SimpleExec;

namespace GitStatusInteractive.Core;

internal class GitCommand : IGitCommand
{
    private const string Executable = "git";

    public async Task<GitCommandResult> Read(CancellationToken cancellationToken, params IReadOnlyCollection<string> arguments)
    {
        try
        {
            var (output, _) = await Command
                .ReadAsync(Executable, args: arguments, cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return new(0, output);
        }
        catch (ExitCodeException ex)
        {
            return new(ex.ExitCode, string.Empty);
        }
    }

    public async Task<GitCommandResult> Run(CancellationToken cancellationToken, params IReadOnlyCollection<string> arguments)
    {
        try
        {
            await Command
                .RunAsync(Executable, args: arguments, cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return new(0, string.Empty);
        }
        catch (ExitCodeException ex)
        {
            return new(ex.ExitCode, string.Empty);
        }
    }
}
