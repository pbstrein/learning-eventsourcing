using System;
using Reqnroll;
using Shopping.Cart.Slices.AddItem;

namespace Shopping.Cart.Tests.StepDefinitions;

[Binding]
public sealed class AddItemCommandStepDefinitions
{

	[When("I execute the AddItem command with the following parameters:")]
	public void WhenIExecuteTheAddItemCommand(Table parameters)
	{
		AddItemCommand addItemCommand = new(
			AggregateId: Guid.Parse(parameters.Rows[0]["AggregateId"]),
			Description: parameters.Rows[0]["Description"],
			Image: parameters.Rows[0]["Image"],
			Price: double.Parse(parameters.Rows[0]["Price"]),
			TotalPrice: double.Parse(parameters.Rows[0]["TotalPrice"]),
			ItemId: Guid.Parse(parameters.Rows[0]["ItemId"]),
			ProductId: Guid.Parse(parameters.Rows[0]["ProductId"])
		);

		throw new PendingStepException();
	}

	[Then("the CartCreated event should be created")]
	public void ThenTheCartCreatedEventShouldBeCreated()
	{

		throw new PendingStepException();
	}

	[Then("the ItemAdded event should be created")]
    public void ThenTheItemAddedEventShouldBeCreated()
    {

        throw new PendingStepException();
    }

}
