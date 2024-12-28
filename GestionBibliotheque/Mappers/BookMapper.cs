using System;
using GestionBibliotheque.DTOs;
using GestionBibliotheque.Models;

namespace GestionBibliotheque.Mappers
{
	public static class BookMapper
	{

		public static Book BookAddDtoToBook(BookAddDto vm)
		{
			return new Book
			{
				Author = vm.Author,
				Copies = vm.Copies,
				ISBN = vm.ISBN,
				Price = vm.Price,
				Title = vm.Title,
				Year = vm.Year
			};
		}

		

		public static IList<BookDto> BookToBookDto(IList<Book> books)
		{
            IList<BookDto> booksVM = new List<BookDto>();
			foreach(Book book in books)
			{
				booksVM.Add(new BookDto
				{
					Author = book.Author,
					Copies = book.Copies,
					ISBN = book.ISBN,
					Price = book.Price,
					Title = book.Title,
					Year = book.Year
				});
			}
			return booksVM;
		}

        public static BookDto BookToBookDto(Book book)
        {
            return new BookDto
            {
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                Price = book.Price,
                Copies = book.Copies,
                Year = book.Year
            };
        }

        public static Book BookDtoToBook(BookDto bookModel)
        {
            return new Book
            {
                Title = bookModel.Title,
                Author = bookModel.Author,
                ISBN = bookModel.ISBN,
                Price = bookModel.Price,
                Copies = bookModel.Copies,
                Year = bookModel.Year
            };
        }



    }
}

