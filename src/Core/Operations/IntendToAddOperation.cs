namespace GitStatusInteractive.Core.Operations;

internal sealed class IntendToAddOperation(IGitCommand command) : IOperation
{
    private readonly IGitCommand _command = command;

    public async Task<OperationResult> Execute(OperationContext context, CancellationToken cancellationToken)
    {
        string[] arguments =
        [
            "add",
            "--intent-to-add",
            context.Pathspec,
        ];

        var commandResult = await _command.Run(cancellationToken, arguments)
            .ConfigureAwait(false);

        return OperationResult.FromCommandResult(commandResult);
    }
}
