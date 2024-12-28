using System;
namespace GestionBibliotheque.Exceptions
{
	public class InvalidIdException : Exception
	{
		public InvalidIdException(string message) : base(message)
		{
		}
	}
}

