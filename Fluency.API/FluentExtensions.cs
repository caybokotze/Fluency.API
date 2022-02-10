namespace Fluency;

public static class FluentExtensions
{
    public static ConfigurableEndpoint<T> ConfigureEndpoint<T>(this IEndpointRouteBuilder builder) where T : class, new()
    {
        return new ConfigurableEndpoint<T>(builder, new T());
    }
    
    public static ConfigurableEndpoint<T> ConfigureEndpoint<T>(this IEndpointRouteBuilder builder, Func<T> factory) where T : class
    {
        return new ConfigurableEndpoint<T>(builder, factory.Invoke());
    }
}