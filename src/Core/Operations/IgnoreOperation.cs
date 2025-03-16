namespace GitStatusInteractive.Core.Operations;

internal sealed class IgnoreOperation : IOperation
{
    public Task<OperationResult> Execute(OperationContext context, CancellationToken cancellationToken)
        => Task.FromResult(new OperationResult(true));
}
