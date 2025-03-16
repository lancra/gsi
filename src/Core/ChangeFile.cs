namespace GitStatusInteractive.Core;

/// <summary>
/// Represents the changes for a file across areas.
/// </summary>
public record ChangeFile
{
    internal ChangeFile(ChangeIndicator stagingIndicator, ChangeIndicator workingIndicator, string path)
    {
        StagingIndicator = stagingIndicator;
        WorkingIndicator = workingIndicator;
        Path = path;
    }

    /// <summary>
    /// Gets the status indicator shown for the Staging area.
    /// </summary>
    public ChangeIndicator StagingIndicator { get; init; }

    /// <summary>
    /// Gets the status indicator shown for the Working area.
    /// </summary>
    public ChangeIndicator WorkingIndicator { get; init; }

    /// <summary>
    /// Gets the path of the file.
    /// </summary>
    public string Path { get; init; }
}
