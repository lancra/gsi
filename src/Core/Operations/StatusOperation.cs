namespace GitStatusInteractive.Core.Operations;

internal sealed class StatusOperation(IGitCommand command, IPrinter printer) : IOperation
{
    private readonly IGitCommand _command = command;
    private readonly IPrinter _printer = printer;

    public async Task<OperationResult> Execute(OperationContext context, CancellationToken cancellationToken)
    {
        string[] arguments =
        [
            "status",
            "--short",
            "--untracked-files",
            context.Pathspec,
        ];

        // TODO: Handle error condition.
        var commandResult = await _command.Read(cancellationToken, arguments)
            .ConfigureAwait(false);

        var files = new List<ChangeFile>();
        var commandOutputLines = commandResult.Output.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in commandOutputLines)
        {
            var stagingAreaIndicator = new ChangeAreaIndicator(ChangeArea.Staging, ChangeIndicator.FromValue(line[0]));
            var workingAreaIndicator = new ChangeAreaIndicator(ChangeArea.Working, ChangeIndicator.FromValue(line[1]));
            var path = line[3..];

            files.Add(new([stagingAreaIndicator, workingAreaIndicator], path));
        }

        var group = new ChangeGroup(files);
        _printer.PrintChanges(group);

        return OperationResult.FromCommandResult(commandResult);
    }
}
