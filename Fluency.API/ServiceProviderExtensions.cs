namespace Fluency;

public static class ServiceProviderExtensions
{
    public static T Resolve<T>(this ServiceProvider provider) where T : notnull
    {
        return provider.GetRequiredService<T>();
    }
    
    public static T Resolve<T>(this IApplicationBuilder builder) where T : notnull
    {
        return builder.ApplicationServices.GetRequiredService<T>();
    }
}