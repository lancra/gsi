namespace GitStatusInteractive.Core.Operations;

internal sealed class RestoreOperation(IGitCommand command) : IOperation
{
    private readonly IGitCommand _command = command;

    public async Task<OperationResult> Execute(OperationContext context, CancellationToken cancellationToken)
    {
        var arguments = new List<string>
        {
            "restore",
        };

        if (context.Area is not null && context.Area == ChangeArea.Staging)
        {
            arguments.Add("--staged");
        }

        arguments.Add(context.Pathspec);

        var commandResult = await _command.Run(cancellationToken, arguments)
            .ConfigureAwait(false);

        return OperationResult.FromCommandResult(commandResult);
    }
}
