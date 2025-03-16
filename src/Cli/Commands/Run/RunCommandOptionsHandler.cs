namespace GitStatusInteractive.Cli.Commands.Run;

internal sealed class RunCommandOptionsHandler : ICommandOptionsHandler<RunCommandOptions>
{
    public Task<int> Handle(RunCommandOptions options, CancellationToken cancellationToken)
        => Task.FromResult(ExitCodes.Success);
}
