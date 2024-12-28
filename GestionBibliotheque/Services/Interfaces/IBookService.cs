using System;
using GestionBibliotheque.DTOs;
using GestionBibliotheque.Models;

namespace GestionBibliotheque.Services.Interfaces
{
    /// <summary>
    /// Interface qui définit les opérations disponibles pour la gestion des livres.
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Ajoute un nouveau livre dans la collection.
        /// </summary>
        /// <param name="bookModel">Le modèle de données du livre à ajouter.</param>
        /// <returns>Le livre ajouté après l'insertion dans la collection.</returns>
        /// <exception cref="DuplicateISBNException">Lève une exception si l'ISBN du livre existe déjà.</exception>
        Book AddBook(BookAddDto bookModel);

        /// <summary>
        /// Met à jour les informations d'un livre existant.
        /// </summary>
        /// <param name="id">L'ID du livre à mettre à jour.</param>
        /// <param name="bookModel">Le modèle contenant les nouvelles données du livre.</param>
        /// <exception cref="InvalidIdException">Lève une exception si l'ID ne correspond pas à celui du livre à mettre à jour.</exception>
        void UpdateBook(string id, BookUpdateDto bookModel);

        /// <summary>
        /// Récupère tous les livres disponibles.
        /// </summary>
        /// <returns>Une liste de tous les livres sous forme de <see cref="BookDto"/>.</returns>
        IList<BookDto> GetAllBooks();

        /// <summary>
        /// Supprime un livre de la collection.
        /// </summary>
        /// <param name="id">L'ID du livre à supprimer.</param>
        /// <exception cref="BookNotFoundException">Lève une exception si le livre à supprimer n'existe pas.</exception>
        void DeleteBook(string id);

        /// <summary>
        /// Recherche un livre par son ID et son titre.
        /// </summary>
        /// <param name="filterDto">Le DTO contenant l'ID et le titre du livre à rechercher.</param>
        /// <returns>Le livre trouvé sous forme de <see cref="BookDto"/>.</returns>
        /// <exception cref="BookNotFoundException">Lève une exception si aucun livre correspondant n'est trouvé.</exception>
        BookDto GetBookByIdAndTitle(BookFilterDto filterDto);
    }
}
