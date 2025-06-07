using Microsoft.AspNetCore.Mvc;
using Shopping.Cart.Events;
using Shopping.Cart.EventStore;

namespace Shopping.Cart.Slices.AddItem;

public static class AddItemExtensions
{
	public static RouteHandlerBuilder MapAddItemCommand(this IEndpointRouteBuilder builder)
	{
		return builder.MapPost("/command/addItem", ([FromBody] AddItemCommand command, IEventStore eventStore) =>
		{
			List<IEvent> events = new List<IEvent>()
			{
				new CartCreatedEvent(command.AggregateId),
				new ItemAddedEvent(
					command.AggregateId,
					command.Description,
					command.Image,
					command.Price,
					command.ItemId,
					command.ProductId)
			};
			eventStore.AppendToStream(command.AggregateId.ToString(), events);

			return events;
		});
	}
}