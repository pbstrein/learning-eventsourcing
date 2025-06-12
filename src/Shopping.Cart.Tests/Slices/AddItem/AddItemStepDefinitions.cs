using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reqnroll;
using Shopping.Cart.Events;
using Shopping.Cart.EventStore;
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
    public async Task ThenTheCartCreatedEventShouldBeCreated()
    {
        IEventStore eventStore = _webTestContext.Factory.Services.GetRequiredService<IEventStore>();

        IEnumerable<IEvent> events = await eventStore.ReadAll();

        IEnumerable<CartCreatedEvent> cartCreatedEvents = events.OfType<CartCreatedEvent>();
        Assert.AreEqual(1, cartCreatedEvents.Count(), "Expected exactly one CartCreated event to be created.");
    }

    [Then("the ItemAdded event should be created")]
    public async Task ThenTheItemAddedEventShouldBeCreated()
    {

        IEventStore eventStore = _webTestContext.Factory.Services.GetRequiredService<IEventStore>();

        IEnumerable<IEvent> events = await eventStore.ReadAll();

        IEnumerable<ItemAddedEvent> itemAddedEvents = events.OfType<ItemAddedEvent>();
        Assert.AreEqual(1, itemAddedEvents.Count(), "Expected exactly one ItemAdded event to be created.");
    }

    [Then("there should be {int} events for the aggregate {string}")]
    public async Task ThenThereShouldBeEventsForTheAggregate(int expectedCount, string aggregateId)
    {
        IEventStore eventStore = _webTestContext.Factory.Services.GetRequiredService<IEventStore>();

        IEnumerable<IEvent> events = await eventStore.ReadStream(aggregateId);

        Assert.AreEqual(expectedCount, events.Count(), $"Expected {expectedCount} events for aggregate {aggregateId}.");
    }

}
