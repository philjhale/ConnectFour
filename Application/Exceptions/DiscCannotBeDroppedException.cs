using System;

namespace ConnectFour.Application.Exceptions
{
	public class DiscCannotBeDroppedException : Exception
	{
		public DiscCannotBeDroppedException(string message) : base(message) { }
	}
}