using Ardalis.SmartEnum;

namespace GitStatusInteractive.Core;

/// <summary>
/// Represents the area which a change is represented in.
/// </summary>
public class ChangeArea : SmartEnum<ChangeArea>
{
    /// <summary>
    /// Specifies the file system changes.
    /// </summary>
    public static readonly ChangeArea Working = new("Working", 0, ChangeIndicatorColor.Red);

    /// <summary>
    /// Specifies the changes staged for inclusion.
    /// </summary>
    public static readonly ChangeArea Staging = new("Staging", 1, ChangeIndicatorColor.Green);

    private ChangeArea(string name, int value, ChangeIndicatorColor color)
        : base(name, value)
        => Color = color;

    /// <summary>
    /// Gets the default color for a status indicator within the area.
    /// </summary>
    internal ChangeIndicatorColor Color { get; }
}
