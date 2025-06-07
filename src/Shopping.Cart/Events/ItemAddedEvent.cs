namespace Shopping.Cart.Events;

public record ItemAddedEvent(
	Guid AggregateId,
	string Description,
	string Image,
	double Price,
	Guid ItemId,
	Guid ProductId) : IEvent
{
}