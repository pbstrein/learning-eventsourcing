using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace Shopping.Cart.Tests.Common;

public class WebTestContext
{
    public CustomWebApplicationFactory Factory { get; private set; }
    public HttpClient Client { get; private set; }
    public HttpResponseMessage LastResponse { get; set; }
    public string LastResponseBody { get; set; }
    
    

    public void Initialize()
    {
        Factory = new CustomWebApplicationFactory();
        Client = Factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }

    public void Reset()
    {
        LastResponse = null;
        LastResponseBody = null;
        Dispose();
    }

    public T DeserializeResponse<T>()
    {
        if (LastResponse == null)
        {
            throw new InvalidOperationException("No response available to deserialize");
        }

        return  JsonConvert.DeserializeObject<T>(LastResponseBody);
    }
    
    public void Dispose()
    {
        Client?.Dispose();
        Factory?.Dispose();
    }
}
