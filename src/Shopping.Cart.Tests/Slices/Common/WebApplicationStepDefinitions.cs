using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Reqnroll;

namespace Shopping.Cart.Tests.Common;

[Binding]
public sealed class WebApplicationStepDefinitions
{
    private readonly WebTestContext _webTestContext;
    
    public WebApplicationStepDefinitions(WebTestContext WebTestContext)
    {
        _webTestContext = WebTestContext;
    }
    
    [BeforeScenario]
    public void InitializeWebApplicationFactory()
    {
        _webTestContext.Initialize();
    }
    
    [AfterScenario]
    public void CleanupWebApplicationFactory()
    {
        _webTestContext.Reset();
    }
    

}