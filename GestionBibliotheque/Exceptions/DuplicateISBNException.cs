using System;
namespace GestionBibliotheque.Exceptions
{
	public class DuplicateISBNException : Exception
	{
		public DuplicateISBNException(string message) : base(message)
		{
		}
	}
}

