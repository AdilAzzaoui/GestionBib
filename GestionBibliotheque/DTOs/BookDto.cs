using System;
namespace GestionBibliotheque.DTOs
{
	public class BookDto
	{
        public string Title { get;  set; }
        public string Author { get;  set; }
        public string ISBN { get;  set; }
        public decimal Price { get;  set; }
        public int Copies { get;  set; }
        public int Year { get;  set; }
    }
}

