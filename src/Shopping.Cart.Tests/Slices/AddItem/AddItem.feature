Feature: Add Item

This implements the Add Item slice.

Scenario: Executing AddItem adds the appropriate events

	When I execute the AddItem command with the following parameters:
	    | Field	      | Value                                  |
		| AggregateId | 12345678-1234-1234-1234-123456789012 |
		| Description | Test Item Description                |
		| Image       | http://example.com/image.png         |
		| Price       | 19.99                                |
		| ItemId      | 12345678-1234-1234-1234-123456789012 |                                   
		| ProductId   | 12345678-1234-1234-1234-123456789012 |
	Then the ItemAdded event should be created
	And the CartCreated event should be created	