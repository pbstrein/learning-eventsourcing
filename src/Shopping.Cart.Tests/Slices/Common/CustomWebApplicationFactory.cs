using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shopping.Cart.EventStore;

namespace Shopping.Cart.Tests.Common;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Replace services with test implementations if needed
            // For example, you might want to replace the event store with a test version
            services.AddSingleton<IEventStore, InMemoryEventStore>();
            
            // Add any other test services or configurations
        });
    }
}
