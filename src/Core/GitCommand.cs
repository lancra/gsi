using SimpleExec;

namespace Gint.Core;

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

            // Even on Windows, Git outputs Unix newlines.
            var lines = output?.Split("\n", StringSplitOptions.RemoveEmptyEntries) ?? [];
            return new(0, lines);
        }
        catch (ExitCodeException ex)
        {
            return new(ex.ExitCode, []);
        }
    }

    public async Task<GitCommandResult> Run(CancellationToken cancellationToken, params IReadOnlyCollection<string> arguments)
    {
        try
        {
            await Command
                .RunAsync(Executable, args: arguments, noEcho: true, cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return new(0, []);
        }
        catch (ExitCodeException ex)
        {
            return new(ex.ExitCode, []);
        }
    }
}
