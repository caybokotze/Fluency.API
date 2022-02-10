namespace Fluency;

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