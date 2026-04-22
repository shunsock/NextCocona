namespace Cocona.Application;

public interface ICoconaServiceProviderScopeSupport
{
    (IDisposable Scope, IServiceProvider ScopedServiceProvider) CreateScope(IServiceProvider serviceProvider);
    (IAsyncDisposable Scope, IServiceProvider ScopedServiceProvider) CreateAsyncScope(IServiceProvider serviceProvider);
}