using System;
using Reqnroll;
using Shopping.Cart.Slices.AddItem;

namespace Shopping.Cart.Tests.StepDefinitions;

[Binding]
public sealed class AddItemCommandStepDefinitions
{

	[When("I execute the AddItem command with the following parameters:")]
	public void WhenIExecuteTheAddItemCommand(AddItemCommand command)
	{
		throw new PendingStepException();
	}


	[StepArgumentTransformation]
	public AddItemCommand TransformAddItemCommand(DataTable table)
	{
		return table.CreateInstance<AddItemCommand>()
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
