using GitStatusInteractive.Core.Operations;
using Microsoft.Extensions.DependencyInjection;

namespace GitStatusInteractive.Core;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddSingleton<IGitCommand, GitCommand>();

        var operationServiceType = typeof(IOperation);
        foreach (var descriptor in OperationDescriptor.List)
        {
            services.AddKeyedScoped(operationServiceType, descriptor.Value, descriptor.Type);
        }

        return services;
    }
}
