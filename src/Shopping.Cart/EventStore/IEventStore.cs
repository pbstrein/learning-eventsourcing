namespace Shopping.Cart.EventStore;

/// <summary>
/// Generic interface for an event store.
/// An event store is a storage system that persists events in a way that they can be replayed later.
/// </summary>
public interface IEventStore
{
	/// <summary>
	/// Saves an event to the event store.
	/// </summary>
	/// <param name="event">The event to save.</param>
	public Task AppendToStream(string streamId, IEnumerable<IEvent> events);

	/// <summary>
	/// Reads events from a specific stream in the event store.
	/// </summary>
	/// <param name="streamId">The ID of the stream to read from.</param>
	/// <returns>All events in the specified stream.</returns>
	public Task<IEnumerable<IEvent>> ReadStream(string streamId);

	/// <summary>
	/// Reads all events from the event store.
	/// </summary>
	/// <returns>All events in the event store.</returns>
	public Task<IEnumerable<IEvent>> ReadAll();

}