using Ardalis.SmartEnum;
using Gint.Core.Changes;

namespace Gint.Core.Operations;

/// <summary>
/// Represents the descriptor for an operation.
/// </summary>
public class OperationDescriptor : SmartEnum<OperationDescriptor, char>
{
    /// <summary>
    /// Specifies that the operation will add changes to the staging area.
    /// </summary>
    public static readonly OperationDescriptor Add = new(
        "Add",
        'a',
        "Add changes to the staging area.",
        OperationKind.Write,
        areas: [ChangeArea.Working]);

    /// <summary>
    /// Specifies that the operation will break changes into separate files.
    /// </summary>
    public static readonly OperationDescriptor Break = new(
        "Break",
        'b',
        "Break changes into separate files.",
        OperationKind.Control,
        scopes: [OperationScope.All]);

    /// <summary>
    /// Specifies that the operation will show the differences introduced by changes.
    /// </summary>
    public static readonly OperationDescriptor Diff = new(
        "Diff",
        'd',
        "Show the differences introduced by changes.",
        OperationKind.Read,
        areas: ChangeArea.List);

    /// <summary>
    /// Specifies that the operation will restore a fragment of changes.
    /// </summary>
    public static readonly OperationDescriptor FragmentalRestore = new(
        "FragmentalRestore",
        'f',
        "Restore a fragment of changes.",
        OperationKind.Write,
        areas: ChangeArea.List);

    /// <summary>
    /// Specifies that the operation will print the application help.
    /// </summary>
    public static readonly OperationDescriptor Help = new(
        "Help",
        '?',
        "Print the application help.",
        OperationKind.Control);

    /// <summary>
    /// Specifies that the operation will perform no action for the changes.
    /// </summary>
    public static readonly OperationDescriptor Ignore = new(
        "Ignore",
        'i',
        "Perform no action for the changes.",
        OperationKind.Control,
        scopes: [OperationScope.File]);

    /// <summary>
    /// Specifies that the operation will mark changes as intended to be added.
    /// </summary>
    public static readonly OperationDescriptor IntendToAdd = new(
        "IntendToAdd",
        'n',
        "Mark changes as intended to be added.",
        OperationKind.Write,
        areas: [ChangeArea.Working]);

    /// <summary>
    /// Specifies that the operation will patch changes to the staging area.
    /// </summary>
    public static readonly OperationDescriptor Patch = new(
        "Patch",
        'p',
        "Patch changes to the staging area.",
        OperationKind.Write,
        areas: [ChangeArea.Working]);

    /// <summary>
    /// Specifies that the operation will quit the application.
    /// </summary>
    public static readonly OperationDescriptor Quit = new(
        "Quit",
        'q',
        "Quit the application.",
        OperationKind.Control);

    /// <summary>
    /// Specifies that the operation will restore changes.
    /// </summary>
    public static readonly OperationDescriptor Restore = new(
        "Restore",
        'r',
        "Restore changes.",
        OperationKind.Write,
        areas: ChangeArea.List);

    /// <summary>
    /// Specifies that the operation will show the status of changes.
    /// </summary>
    public static readonly OperationDescriptor Status = new(
        "Status",
        's',
        "Show the status of changes.",
        OperationKind.Read);

    private OperationDescriptor(
        string name,
        char value,
        string description,
        OperationKind kind,
        IReadOnlyCollection<OperationScope>? scopes = default,
        IReadOnlyCollection<ChangeArea>? areas = default)
        : base(name, value)
    {
        Description = description;
        Kind = kind;
        Scopes = scopes ?? OperationScope.List;
        Areas = areas ?? [];
    }

    /// <summary>
    /// Gets the description of the operation.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets the kind of execution performed by the operation.
    /// </summary>
    public OperationKind Kind { get; }

    /// <summary>
    /// Gets the scopes in which the operation can be executed.
    /// </summary>
    public IReadOnlyCollection<OperationScope> Scopes { get; }

    /// <summary>
    /// Gets the change areas that the operation can target.
    /// </summary>
    public IReadOnlyCollection<ChangeArea> Areas { get; }

    /// <summary>
    /// Filters the available list of descriptors.
    /// </summary>
    /// <param name="scope">The scope to filter by.</param>
    /// <param name="changes">The changes to filter by.</param>
    /// <returns>The filtered list of descriptors.</returns>
    public static IReadOnlyCollection<OperationDescriptor> Filter(OperationScope scope, ChangeGroup changes)
        => Sort(
            List.Where(descriptor => descriptor.Scopes.Contains(scope))
                .Where(descriptor => descriptor.Areas.Count == 0 || descriptor.Areas.Any(area => changes.HasActionableFiles(area)))
                .ToArray());

    private static OperationDescriptor[] Sort(IReadOnlyCollection<OperationDescriptor> descriptors)
        => [.. descriptors.OrderBy(descriptor => descriptor.Kind == OperationKind.Control)
        .ThenBy(descriptor => !char.IsLetter(descriptor.Value))
        .ThenBy(descriptor => descriptor.Value)];
}
