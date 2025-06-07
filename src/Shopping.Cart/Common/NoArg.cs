using System;

namespace Shopping.Cart.Common
{
	/// <summary>
	/// Indicates that a class should have a parameterless constructor.
	/// This attribute can be used by code generators or reflection utilities.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class NoArgAttribute : Attribute
	{
		public NoArgAttribute()
		{
		}
	}
}