namespace Shopping.Cart.EventStore;

public class InMemoryEventStore : IEventStore
{
	private readonly Dictionary<string, List<IEvent>> _eventStore = new();

	public Task AppendToStream(string streamId, IEnumerable<IEvent> events)
	{
		if (!_eventStore.ContainsKey(streamId))
		{
			_eventStore[streamId] = new List<IEvent>();
		}

		_eventStore[streamId].AddRange(events);
		return Task.CompletedTask;
	}

	public Task<IEnumerable<IEvent>> ReadStream(string streamId)
	{
		if (_eventStore.TryGetValue(streamId, out var events))
		{
			return Task.FromResult<IEnumerable<IEvent>>(events);
		}

		return Task.FromResult<IEnumerable<IEvent>>(new List<IEvent>());
	}

	public Task<IEnumerable<IEvent>> ReadAll()
	{
		var allEvents = _eventStore.Values.SelectMany(e => e).ToList();
		return Task.FromResult<IEnumerable<IEvent>>(allEvents);
	}

}