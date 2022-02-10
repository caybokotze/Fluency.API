using System.Text;

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

public class ConfigurableEndpoint<T>
{
    private readonly HttpMappingConfiguration<T> _httpMappingConfiguration;

    public ConfigurableEndpoint(IEndpointRouteBuilder endpointBuilder, T instance)
    {
        _httpMappingConfiguration = new HttpMappingConfiguration<T>(endpointBuilder, instance);
    }
    
    public ConfigurableEndpoint<T> With(Action<HttpMappingConfiguration<T>> builder)
    {
        builder(_httpMappingConfiguration);
        return this;
    }
}

public class HttpMappingConfiguration<T>
{
    private readonly IEndpointRouteBuilder _routeBuilder;
    private readonly T _instance;

    public HttpMappingConfiguration(IEndpointRouteBuilder routeBuilder, T instance)
    {
        _routeBuilder = routeBuilder;
        _instance = instance;
    }

    public void Get(string pattern, Action<T> action)
    {
        _routeBuilder.MapGet(pattern, () => action(_instance));
}

    public void Post(string pattern, Action<T> action)
    {
        _routeBuilder.MapPost(pattern, () => action(_instance));
    }

    public void Put(string pattern, Action<T> action)
    {
        _routeBuilder.MapPut(pattern, () => action(_instance));
    }

    public void Delete(string pattern, Action<T> action)
    {
        _routeBuilder.MapDelete(pattern, () => action(_instance));
    }
}