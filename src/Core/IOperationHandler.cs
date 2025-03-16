namespace GitStatusInteractive.Core;

/// <summary>
/// Represents the handler for executing operations from a consumer.
/// </summary>
public interface IOperationHandler
{
    /// <summary>
    /// Executes an operation.
    /// </summary>
    /// <param name="context">The context for the operation to execute.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous operation, containing the operation result.</returns>
    Task<OperationResult> Execute(OperationContext context, CancellationToken cancellationToken);
}
