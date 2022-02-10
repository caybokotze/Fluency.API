using System.Text;
using Microsoft.AspNetCore.Http;

namespace Fluency.API.Tests;

public class TestController
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TestController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public void Route()
    {
        _httpContextAccessor.HttpContext?
            .Response.Body
            .WriteAsync(Encoding.UTF8.GetBytes("Hi there good sir."));
    }
}