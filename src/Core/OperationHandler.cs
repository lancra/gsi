using GitStatusInteractive.Core.Operations;
using Microsoft.Extensions.DependencyInjection;

namespace GitStatusInteractive.Core;

internal sealed class OperationHandler(IKeyedServiceProvider serviceProvider) : IOperationHandler
{
    private readonly IKeyedServiceProvider _serviceProvider = serviceProvider;

    public async Task<OperationResult> Execute(OperationContext context, CancellationToken cancellationToken)
    {
        // TODO: Handle unknown operation.
        var operation = _serviceProvider.GetRequiredKeyedService<IOperation>(context.Descriptor.Value);

        var result = await operation.Execute(context, cancellationToken)
            .ConfigureAwait(false);
        return result;
    }
}
