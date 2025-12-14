using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Application.Services;

/// <summary>
/// Service class for book-related business logic.
/// </summary>
public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public List<Book> GetAllBooks()
    {
        return _bookRepository.GetAll();
    }

    public Book? GetBookById(int id)
    {
        return _bookRepository.GetById(id);
    }

    public int AddBook(Book book)
    {
        ValidateBook(book);

        book.CreatedAt = DateTime.Now;
        book.AvailableCopies = book.TotalCopies;

        return _bookRepository.Add(book);
    }

    public bool UpdateBook(Book book)
    {
        ValidateBook(book);

        var existingBook = _bookRepository.GetById(book.Id);
        if (existingBook == null)
            throw new InvalidOperationException($"Book with ID {book.Id} not found.");

        book.UpdatedAt = DateTime.Now;

        return _bookRepository.Update(book);
    }

    public bool DeleteBook(int id)
    {
        var book = _bookRepository.GetById(id);
        if (book == null)
            throw new InvalidOperationException($"Book with ID {id} not found.");

        return _bookRepository.Delete(id);
    }

    private void ValidateBook(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title))
            throw new ArgumentException("Book title cannot be empty.", nameof(book));

        if (string.IsNullOrWhiteSpace(book.Author))
            throw new ArgumentException("Book author cannot be empty.", nameof(book));

        if (string.IsNullOrWhiteSpace(book.ISBN))
            throw new ArgumentException("Book ISBN cannot be empty.", nameof(book));

        if (book.TotalCopies < 1)
            throw new ArgumentException("Total copies must be at least 1.", nameof(book));
    }
}
