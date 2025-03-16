namespace GitStatusInteractive.Core;

internal record OperationContext(
    string Path,
    ChangeArea? Area = default)
{
}
