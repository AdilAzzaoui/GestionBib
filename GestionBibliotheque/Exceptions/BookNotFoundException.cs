using System;
namespace GestionBibliotheque.Exceptions
{
	public class BookNotFoundException : Exception
	{
		public BookNotFoundException(string message) : base(message)
		{}
	}
}

