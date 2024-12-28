using System;

namespace GestionBibliotheque.Models
{
	public class Book
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string ISBN { get; set; }
		public decimal Price { get; set; }
		public string Author { get; set; }
		public int Year { get; set; }
		public int Copies { get; set; }

    }
}

