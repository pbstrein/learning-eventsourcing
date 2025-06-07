namespace Shopping.Cart.Common
{
	/// <summary>
	/// Represents a command in the system.
	/// </summary>
	public interface ICommand
	{
		Guid AggregateId { get; }
	}
}