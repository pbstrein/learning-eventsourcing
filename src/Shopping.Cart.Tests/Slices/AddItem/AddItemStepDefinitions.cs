using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Reqnroll;
using Shopping.Cart.Slices.AddItem;
using Shopping.Cart.Tests.Common;

namespace Shopping.Cart.Tests.StepDefinitions;

[Binding]
public sealed class AddItemCommandStepDefinitions
{
    private readonly WebTestContext _webTestContext;
    
    public AddItemCommandStepDefinitions(WebTestContext WebTestContext)
    {
        _webTestContext = WebTestContext;
    }

    [When("I execute the AddItem command with the following parameters:")]
    public async Task WhenIExecuteTheAddItemCommand(AddItemCommand command)
    {
        var jsonContent = new StringContent(
            JsonSerializer.Serialize(command),
            Encoding.UTF8,
            "application/json");
            
        _webTestContext.LastResponse = await _webTestContext.Client.PostAsync("/command/addItem", jsonContent);
        _webTestContext.LastResponseBody = await _webTestContext.LastResponse.Content.ReadAsStringAsync();
    }

    [StepArgumentTransformation]
    public AddItemCommand TransformAddItemCommand(DataTable table)
    {
        return table.CreateInstance<AddItemCommand>();
    }

    [Then("the CartCreated event should be created")]
    public void ThenTheCartCreatedEventShouldBeCreated()
    {
        // For now, we're just checking that the request was successful
        // In a real implementation, you would verify the event was created
        // possibly by querying an endpoint that returns events or checking the event store
        
        if (!_webTestContext.LastResponse.IsSuccessStatusCode)
        {
            throw new Exception($"Request failed with status {_webTestContext.LastResponse.StatusCode}. Body: {_webTestContext.LastResponseBody}");
        }
    }

    [Then("the ItemAdded event should be created")]
    public void ThenTheItemAddedEventShouldBeCreated()
    {
        // For now, we're just checking that the request was successful
        // In a real implementation, you would verify the event was created
        // possibly by querying an endpoint that returns events or checking the event store
        
        if (!_webTestContext.LastResponse.IsSuccessStatusCode)
        {
            throw new Exception($"Request failed with status {_webTestContext.LastResponse.StatusCode}. Body: {_webTestContext.LastResponseBody}");
        }

    }

}
