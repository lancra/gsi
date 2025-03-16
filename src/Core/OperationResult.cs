namespace GitStatusInteractive.Core;

/// <summary>
/// Represents the result of an operation execution.
/// </summary>
/// <param name="Succeeded">The value that determines whether the operation succeeded.</param>
/// <param name="Exit">The value that determines whether the application should exit.</param>
public record OperationResult(bool Succeeded, bool Exit)
{
    internal OperationResult(bool succeeded)
        : this(succeeded, false)
    {
    }

    internal static OperationResult FromCommandResult(GitCommandResult commandResult)
        => new(commandResult.Succeeded);
}
