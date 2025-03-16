namespace GitStatusInteractive.Core.Operations;

internal sealed class PatchOperation(IGitCommand command) : IOperation
{
    private readonly IGitCommand _command = command;

    public async Task<OperationResult> Execute(OperationContext context, CancellationToken cancellationToken)
    {
        string[] arguments =
        [
            "add",
            "--patch",
            context.Pathspec,
        ];

        var commandResult = await _command.Run(cancellationToken, arguments)
            .ConfigureAwait(false);

        return OperationResult.FromCommandResult(commandResult);
    }
}
