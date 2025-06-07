namespace Shopping.Cart.Events;

public record CartCreatedEvent(
	Guid AggregateId
) : IEvent
{
}