namespace Fluency;

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