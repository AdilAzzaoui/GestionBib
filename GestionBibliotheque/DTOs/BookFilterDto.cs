using System;
using System.ComponentModel.DataAnnotations;

namespace GestionBibliotheque.DTOs
{
    public class BookFilterDto
    {
        [Required(ErrorMessage = "L'ID est requis.")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Le titre est requis.")]
        public string Title { get; set; }
    }
}

