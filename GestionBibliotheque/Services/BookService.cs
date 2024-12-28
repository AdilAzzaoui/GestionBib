using System;
using GestionBibliotheque.DTOs;
using GestionBibliotheque.Exceptions;
using GestionBibliotheque.Mappers;
using GestionBibliotheque.Models;
using GestionBibliotheque.Services.Interfaces;

namespace GestionBibliotheque.Services
{
    /// <summary>
    /// Implémentation du service de gestion des livres.
    /// </summary>

    public class BookService : IBookService
	{
        public IList<Book> books;
        private readonly IGeneratorService _generator;

		public BookService(IGeneratorService generator)
		{
            books = new List<Book>();
            _generator = generator;
		}

        /// <inheritdoc/>
        
        public Book AddBook(BookAddDto bookModel)
        {

            if (bookModel == null) throw new BookNotFoundException("Book Not Found !");
            Book book = BookMapper.BookAddDtoToBook(bookModel);
            if (BookExist(book.ISBN))
            {
                throw new DuplicateISBNException("The book's ISBN already exists !");
            }
            book.Id = _generator.GenerateId();
            books.Add(book);
            return book;  
        }

        /// <inheritdoc/>
        public void DeleteBook(string id)
        {
            Book book = GetBookById(id) ?? throw new BookNotFoundException("Book Not Found !");
            books.Remove(book);
        }

        /// <inheritdoc/>
        public IList<BookDto> GetAllBooks()
        {
            return BookMapper.BookToBookDto(this.books);
        }

        /// <inheritdoc/>
        public void UpdateBook(string id , BookUpdateDto bookModel)
        {
            if(id != bookModel.Id)
            {
                throw new InvalidIdException("Invalid Id !");
            }
            if (BookExist(bookModel.ISBN))
            {
                throw new DuplicateISBNException("Un livre est déja exist avec le mème ISBN"); ;
            }
            Book book = GetBookById(id);
            book.Author = bookModel.Author;
            book.Copies = bookModel.Copies;
            book.ISBN = bookModel.ISBN;
            book.Price = bookModel.Price;
            book.Title = bookModel.Title;
            book.Year = bookModel.Year;
        }

        /// <inheritdoc/>
        public BookDto GetBookByIdAndTitle(BookFilterDto filterDto)
        {
            Book book = books.FirstOrDefault(b => b.Id == filterDto.Id && b.Title.Equals(filterDto.Title, StringComparison.OrdinalIgnoreCase)) ?? throw new BookNotFoundException("Aucun livre trouvé !.");

            return BookMapper.BookToBookDto(book);
        }

        private Book GetBookById(string id)
        {
            return books.FirstOrDefault(b => b.Id == id) ?? throw new BookNotFoundException("Book Not Found !");
        }

        private bool BookExist(string ISBN)
        {
            return books.Any(b => b.ISBN == ISBN);
        }
    }
}

