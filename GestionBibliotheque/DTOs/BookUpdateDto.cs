using System;
using System.ComponentModel.DataAnnotations;


namespace GestionBibliotheque.DTOs
{
	public class BookUpdateDto
	{
        public string Id { get; set; }
        public string Title { get; set; }
        [RegularExpression(@"^\d{10}(\d{3})?$")]
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Copies { get; set; }
    }
}

