namespace GitStatusInteractive.Core;

/// <summary>
/// Represents all changes across areas.
/// </summary>
public record ChangeGroup
{
    internal ChangeGroup(IReadOnlyCollection<ChangeFile> files)
        => Files = files;

    /// <summary>
    /// Gets the changes for each file.
    /// </summary>
    public IReadOnlyCollection<ChangeFile> Files { get; init; }
}
