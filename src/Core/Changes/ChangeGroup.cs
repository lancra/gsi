namespace Gint.Core.Changes;

/// <summary>
/// Represents all changes across areas.
/// </summary>
public record ChangeGroup
{
    private readonly Dictionary<ChangeArea, List<ChangeFile>> _actionableAreaChanges = ChangeArea.List
        .ToDictionary(area => area, area => new List<ChangeFile>());

    internal ChangeGroup(IReadOnlyCollection<ChangeFile> files)
    {
        Files = files;

        foreach (var file in files)
        {
            foreach (var areaIndicator in file.Indicators.Where(areaIndicator => areaIndicator.Indicator.Actionable))
            {
                _actionableAreaChanges[areaIndicator.Area].Add(file);
            }
        }
    }

    /// <summary>
    /// Gets the changes for each file.
    /// </summary>
    public IReadOnlyCollection<ChangeFile> Files { get; init; }

    /// <summary>
    /// Gets a value indicating whether actionable files are present.
    /// </summary>
    /// <param name="area">The area to check for actionable files.</param>
    /// <returns><c>true</c> when the area has actionable files; otherwise, <c>false</c>.</returns>
    public bool HasActionableFiles(ChangeArea area) => _actionableAreaChanges[area].Count > 0;
}
