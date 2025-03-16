namespace GitStatusInteractive.Core.Operations;

internal sealed class BreakOperation : IOperation
{
    // TODO: Implement splitting by file.
    public Task<OperationResult> Execute(OperationContext context, CancellationToken cancellationToken)
        => Task.FromResult(new OperationResult(true));
}
