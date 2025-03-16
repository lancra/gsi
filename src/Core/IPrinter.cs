namespace GitStatusInteractive.Core;

/// <summary>
/// Represents the printer for application output.
/// </summary>
public interface IPrinter
{
    /// <summary>
    /// Print a group of changes.
    /// </summary>
    /// <param name="changes">The change group to print.</param>
    void PrintChanges(ChangeGroup changes);

    /// <summary>
    /// Print a single line.
    /// </summary>
    /// <param name="value">The line to print.</param>
    void PrintLine(string value);
}
