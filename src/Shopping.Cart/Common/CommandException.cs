namespace Shopping.Cart.Common
{
	/// <summary>
	/// Represents an exception that occurs during command processing.
	/// </summary>
	public class CommandException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CommandException"/> class with a specified error message.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public CommandException(string message) : base(message)
		{
		}
	}
}