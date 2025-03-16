using Ardalis.SmartEnum;

namespace GitStatusInteractive.Core;

/// <summary>
/// Represents the color of a change indicator.
/// </summary>
public class ChangeIndicatorColor : SmartEnum<ChangeIndicatorColor>
{
    /// <summary>
    /// Specifies the red color for a change indicator.
    /// </summary>
    public static readonly ChangeIndicatorColor Red = new("Red", 1);

    /// <summary>
    /// Specifies the green color for a change indicator.
    /// </summary>
    public static readonly ChangeIndicatorColor Green = new("Green", 2);

    private ChangeIndicatorColor(string name, int value)
        : base(name, value)
    {
    }
}
