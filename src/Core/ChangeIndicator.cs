using Ardalis.SmartEnum;

namespace GitStatusInteractive.Core;

/// <summary>
/// Represents the indicator assigned for the changes in an area and file.
/// </summary>
public class ChangeIndicator : SmartEnum<ChangeIndicator, char>
{
    /// <summary>
    /// Specifies that the file is added or is intended to be added.
    /// </summary>
    public static readonly ChangeIndicator Added = new("Added", 'A');

    /// <summary>
    /// Specifies that the file is copied.
    /// </summary>
    public static readonly ChangeIndicator Copied = new("Copied", 'C');

    /// <summary>
    /// Specifies that the file is deleted.
    /// </summary>
    public static readonly ChangeIndicator Deleted = new("Deleted", 'D');

    /// <summary>
    /// Specifies that the file is ignored.
    /// </summary>
    public static readonly ChangeIndicator Ignored = new("Ignored", '!', stagingAreaColor: ChangeIndicatorColor.Red);

    /// <summary>
    /// Specifies that the file is modified.
    /// </summary>
    public static readonly ChangeIndicator Modified = new("Modified", 'M');

    /// <summary>
    /// Specifies that the file is renamed.
    /// </summary>
    public static readonly ChangeIndicator Renamed = new("Renamed", 'R');

    /// <summary>
    /// Specifies that the file type is changed.
    /// </summary>
    public static readonly ChangeIndicator TypeChanged = new("TypeChanged", 'T');

    /// <summary>
    /// Specifies that the file is modified with unresolved merge conflicts.
    /// </summary>
    public static readonly ChangeIndicator Unmerged = new("Unmerged", 'U', stagingAreaColor: ChangeIndicatorColor.Red);

    /// <summary>
    /// Specifies that the file is changed in an unknown way.
    /// </summary>
    public static readonly ChangeIndicator Unknown = new("Unknown", 'X', stagingAreaColor: ChangeIndicatorColor.Red);

    /// <summary>
    /// Specifies that the file is unmodified within an area.
    /// </summary>
    public static readonly ChangeIndicator Unmodified = new("Unmodified", ' ');

    /// <summary>
    /// Specifies that the file is not tracked.
    /// </summary>
    public static readonly ChangeIndicator Untracked = new("Untracked", '?', stagingAreaColor: ChangeIndicatorColor.Red);

    private ChangeIndicator(
        string name,
        char value,
        ChangeIndicatorColor? stagingAreaColor = default)
        : base(name, value)
        => StagingAreaColor = stagingAreaColor;

    /// <summary>
    /// Gets the optional color override for an area.
    /// </summary>
    internal ChangeIndicatorColor? StagingAreaColor { get; }
}
