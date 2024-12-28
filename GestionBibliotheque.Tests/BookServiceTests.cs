using System;
using FluentAssertions;
using GestionBibliotheque.DTOs;
using GestionBibliotheque.Exceptions;
using GestionBibliotheque.Services;
using GestionBibliotheque.Services.Interfaces;
using Moq;

public class BookServiceTests
{
    private readonly BookService _bookService;

    public BookServiceTests()
    {
        var mockGeneratorService = new Mock<IGeneratorService>();
        mockGeneratorService.Setup(gen => gen.GenerateId()).Returns("MockedId");

        _bookService = new BookService(mockGeneratorService.Object);
    }

    [Fact]
    public void AddBook_Should_Add_Book_When_Valid()
    {
        var bookDto = new BookAddDto
        {
            Title = "Clean Code",
            Author = "Robert C. Martin",
            ISBN = "9780132350884",
            Price = 30.5m,
            Year = 2008,
            Copies = 10
        };

        var result = _bookService.AddBook(bookDto);

        result.Should().NotBeNull();
        result.Title.Should().Be(bookDto.Title);
        _bookService.books.Count.Should().Be(1);
    }

    [Fact]
    public void AddBook_Should_Throw_DuplicateISBNException_When_ISBN_Already_Exists()
    {
        var bookDto = new BookAddDto
        {
            Title = "Clean Code",
            Author = "Robert C. Martin",
            ISBN = "9780132350884",
            Price = 30.5m,
            Year = 2008,
            Copies = 10
        };
        _bookService.AddBook(bookDto);

        Action act = () => _bookService.AddBook(bookDto);

        act.Should().Throw<DuplicateISBNException>()
            .WithMessage("The book's ISBN already exists !");
    }

    [Fact]
    public void AddBook_Should_Throw_BookNotFoundException_When_Null()
    {
        Action act = () => _bookService.AddBook(null);

        act.Should().Throw<BookNotFoundException>()
            .WithMessage("Book Not Found !");
    }

    [Fact]
    public void DeleteBook_Should_Remove_Book_When_Valid_Id()
    {
        var bookDto = new BookAddDto
        {
            Title = "Clean Code",
            Author = "Robert C. Martin",
            ISBN = "9780132350884",
            Price = 30.5m,
            Year = 2008,
            Copies = 10
        };
        var book = _bookService.AddBook(bookDto);

   
        _bookService.DeleteBook(book.Id);

        _bookService.books.Should().BeEmpty();
    }

    [Fact]
    public void DeleteBook_Should_Throw_BookNotFoundException_When_Id_Does_Not_Exist()
    {
        Action act = () => _bookService.DeleteBook("NonExistentId");

        act.Should().Throw<BookNotFoundException>()
            .WithMessage("Book Not Found !");
    }

    [Fact]
    public void UpdateBook_Should_Update_Book_When_Valid()
    {
        var bookDto = new BookAddDto
        {
            Title = "Clean Code",
            Author = "Robert C. Martin",
            ISBN = "9780132350884",
            Price = 30.5m,
            Year = 2008,
            Copies = 10
        };
        var book = _bookService.AddBook(bookDto);

        var updateDto = new BookUpdateDto
        {
            Id = book.Id,
            Title = "The Clean Coder",
            Author = "Robert C. Martin",
            ISBN = "9780137081073",
            Price = 40.0m,
            Year = 2011,
            Copies = 5
        };

        _bookService.UpdateBook(book.Id, updateDto);

        var updatedBook = _bookService.books.First();
        updatedBook.Title.Should().Be(updateDto.Title);
        updatedBook.Price.Should().Be(updateDto.Price);
        updatedBook.Year.Should().Be(updateDto.Year);
        updatedBook.Copies.Should().Be(updateDto.Copies);
        updatedBook.ISBN.Should().Be(updateDto.ISBN);
    }

    [Fact]
    public void UpdateBook_Should_Throw_InvalidIdException_When_Id_Does_Not_Match()
    {
        var bookDto = new BookAddDto
        {
            Title = "Clean Code",
            Author = "Robert C. Martin",
            ISBN = "9780132350884",
            Price = 30.5m,
            Year = 2008,
            Copies = 10
        };
        var book = _bookService.AddBook(bookDto);

        var updateDto = new BookUpdateDto
        {
            Id = "InvalidId",
            Title = "The Clean Coder",
            Author = "Robert C. Martin",
            ISBN = "9780137081073",
            Price = 40.0m,
            Year = 2011,
            Copies = 5
        };

        Action act = () => _bookService.UpdateBook(book.Id, updateDto);

        act.Should().Throw<InvalidIdException>()
            .WithMessage("Invalid Id !");
    }

    [Fact]
    public void GetBookByIdAndTitle_Should_Return_Book_When_Valid_Filter()
    {
        var bookDto = new BookAddDto
        {
            Title = "Clean Code",
            Author = "Robert C. Martin",
            ISBN = "9780132350884",
            Price = 30.5m,
            Year = 2008,
            Copies = 10
        };
        var book = _bookService.AddBook(bookDto);

        var filterDto = new BookFilterDto
        {
            Id = book.Id,
            Title = "Clean Code"
        };

  
        var result = _bookService.GetBookByIdAndTitle(filterDto);

        result.Should().NotBeNull();
        result.Title.Should().Be(book.Title);
    }

    [Fact]
    public void GetBookByIdAndTitle_Should_Throw_BookNotFoundException_When_Filter_Invalid()
    {
        var filterDto = new BookFilterDto
        {
            Id = "NonExistentId",
            Title = "Nonexistent Book"
        };

        Action act = () => _bookService.GetBookByIdAndTitle(filterDto);

        act.Should().Throw<BookNotFoundException>()
            .WithMessage("Aucun livre trouvé !.");
    }
}
