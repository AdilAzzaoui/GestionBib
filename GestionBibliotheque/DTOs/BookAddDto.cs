using System;
using System.ComponentModel.DataAnnotations;

namespace GestionBibliotheque.DTOs
{
	public class BookAddDto
	{
        public string Title { get; set; }
        [RegularExpression(@"^\d{10}(\d{3})?$" , ErrorMessage = "ISBN doit etre soit 10 soit 13 lettres")]
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
        public int Copies { get; set; }
        [RegularExpression(@"^\d{4}$", ErrorMessage = "L'année doit être composé de 4 chiffres.")]
        public int Year { get; set; }
    }
}

