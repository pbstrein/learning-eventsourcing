namespace Shopping.Cart.Common
{
	public record CommandResult
	{
		public Guid Identifier { get; init; }
		public long AggregateSequence { get; init; }
	}
}