using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NExpect;
using NUnit.Framework;
using static NExpect.Expectations;

namespace Fluency.API.Tests;

[TestFixture]
public class RoutingTests
{
    [TestFixture]
    public class WhenDefiningGetRoute
    {
        [Test]
        public async Task GetRouteShouldExistInApplicationRoutePipeline()
        {
            // arrange
            var dataSources = new List<EndpointDataSource>();
            
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    webHost.Configure(app =>
                    {
                        app.UseRouting();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.ConfigureEndpoint(() =>
                                    app.ApplicationServices.GetRequiredService<TestController>())
                                .With(w => w.Get("hello/world", r => r.Route()));
                            
                            dataSources = endpoints.DataSources.ToList();
                        });
                        app.Run(handle => handle.Response.StartAsync());
                        app.Build();
                    });
                    webHost.ConfigureServices(config =>
                    {
                        config.AddRouting();
                        config.AddTransient<TestController, TestController>();
                        config.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                    });
                });
            
            // act
            await hostBuilder.StartAsync();
            // assert
            Expect(dataSources[0].Endpoints.Select(s => s.DisplayName))
                .To.Contain("HTTP: GET hello/world");
        }
        
        [Test]
        public async Task PostRouteShouldExistInApplicationRoutePipeline()
        {
            // arrange
            var dataSources = new List<EndpointDataSource>();
            
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    webHost.Configure(app =>
                    {
                        app.UseRouting();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.ConfigureEndpoint(() =>
                                    app.ApplicationServices.GetRequiredService<TestController>())
                                .With(w => w.Post("hello/world", r => r.Route()));
                            
                            dataSources = endpoints.DataSources.ToList();
                        });
                        app.Run(handle => handle.Response.StartAsync());
                        app.Build();
                    });
                    webHost.ConfigureServices(config =>
                    {
                        config.AddRouting();
                        config.AddTransient<TestController, TestController>();
                        config.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                    });
                });
            
            // act
            await hostBuilder.StartAsync();
            // assert
            Expect(dataSources[0].Endpoints.Select(s => s.DisplayName))
                .To.Contain("HTTP: POST hello/world");
        }
        
        [Test]
        public async Task PutRouteShouldExistInApplicationRoutePipeline()
        {
            // arrange
            var dataSources = new List<EndpointDataSource>();
            
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    webHost.Configure(app =>
                    {
                        app.UseRouting();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.ConfigureEndpoint(() =>
                                    app.ApplicationServices.GetRequiredService<TestController>())
                                .With(w => w.Put("hello/world", r => r.Route()));
                            
                            dataSources = endpoints.DataSources.ToList();
                        });
                        app.Run(handle => handle.Response.StartAsync());
                        app.Build();
                    });
                    webHost.ConfigureServices(config =>
                    {
                        config.AddRouting();
                        config.AddTransient<TestController, TestController>();
                        config.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                    });
                });
            
            // act
            await hostBuilder.StartAsync();
            // assert
            Expect(dataSources[0].Endpoints.Select(s => s.DisplayName))
                .To.Contain("HTTP: PUT hello/world");
        }
        
        [Test]
        public async Task DeleteRouteShouldExistInApplicationRoutePipeline()
        {
            // arrange
            var dataSources = new List<EndpointDataSource>();
            
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    webHost.Configure(app =>
                    {
                        app.UseRouting();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.ConfigureEndpoint(() =>
                                    app.ApplicationServices.GetRequiredService<TestController>())
                                .With(w => w.Delete("hello/world", r => r.Route()));
                            
                            dataSources = endpoints.DataSources.ToList();
                        });
                        app.Run(handle => handle.Response.StartAsync());
                        app.Build();
                    });
                    webHost.ConfigureServices(config =>
                    {
                        config.AddRouting();
                        config.AddTransient<TestController, TestController>();
                        config.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                    });
                });
            
            // act
            await hostBuilder.StartAsync();
            // assert
            Expect(dataSources[0].Endpoints.Select(s => s.DisplayName))
                .To.Contain("HTTP: DELETE hello/world");
        }
    }
}