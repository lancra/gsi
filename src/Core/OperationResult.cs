namespace GitStatusInteractive.Core;

internal record OperationResult(bool Succeeded)
{
    public static OperationResult FromCommandResult(GitCommandResult commandResult)
        => new(commandResult.Succeeded);
}
