namespace GitStatusInteractive.Core.Operations;

internal sealed class QuitOperation : IOperation
{
    public Task<OperationResult> Execute(OperationContext context, CancellationToken cancellationToken)
        => Task.FromResult(new OperationResult(true, true));
}
