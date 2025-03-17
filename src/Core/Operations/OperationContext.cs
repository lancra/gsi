using Gint.Core.Changes;

namespace Gint.Core.Operations;

/// <summary>
/// Represents the context for an operation execution.
/// </summary>
/// <param name="Descriptor">The descriptor for the operation to execute.</param>
/// <param name="Pathspec">The pathspec pattern used to limit files.</param>
/// <param name="Area">The optional area which the operation should be executed in.</param>
public record OperationContext(
    OperationDescriptor Descriptor,
    string Pathspec,
    ChangeArea? Area = default)
{
}
