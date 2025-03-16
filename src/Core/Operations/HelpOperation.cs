namespace GitStatusInteractive.Core.Operations;

internal sealed class HelpOperation(IPrinter printer) : IOperation
{
    private readonly IPrinter _printer = printer;

    public Task<OperationResult> Execute(OperationContext context, CancellationToken cancellationToken)
    {
        // TODO: Filter help by changes and area.
        foreach (var descriptor in OperationDescriptor.List.OrderBy(descriptor => descriptor.Trailing)
            .ThenBy(descriptor => !char.IsLetter(descriptor.Value))
            .ThenBy(descriptor => descriptor.Value))
        {
            var line = $"{descriptor.Value} - {descriptor.Description}";
            _printer.PrintLine(line);
        }

        return Task.FromResult(new OperationResult(true));
    }
}
