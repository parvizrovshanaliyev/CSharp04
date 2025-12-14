using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Application.Services;

/// <summary>
/// Service class for book borrowing business logic.
/// </summary>
public class BookBorrowService : IBookBorrowService
{
    private readonly IBookBorrowRepository _borrowRepository;

    public BookBorrowService(IBookBorrowRepository borrowRepository)
    {
        _borrowRepository = borrowRepository;
    }

    public List<BookBorrowRecord> GetAllBorrows()
    {
        return _borrowRepository.GetAll();
    }

    public BookBorrowRecord? GetBorrowById(int id)
    {
        return _borrowRepository.GetById(id);
    }

    public int AddBorrow(BookBorrowRecord record)
    {
        ValidateBorrowRecord(record);

        record.CreatedAt = DateTime.Now;
        record.IsReturned = false;

        return _borrowRepository.Add(record);
    }

    public bool UpdateBorrow(BookBorrowRecord record)
    {
        var existingRecord = _borrowRepository.GetById(record.Id);
        if (existingRecord == null)
            throw new InvalidOperationException($"Borrow record with ID {record.Id} not found.");

        record.UpdatedAt = DateTime.Now;

        return _borrowRepository.Update(record);
    }

    public bool DeleteBorrow(int id)
    {
        var record = _borrowRepository.GetById(id);
        if (record == null)
            throw new InvalidOperationException($"Borrow record with ID {id} not found.");

        return _borrowRepository.Delete(id);
    }

    private void ValidateBorrowRecord(BookBorrowRecord record)
    {
        if (record.BookId <= 0)
            throw new ArgumentException("Book ID must be valid.", nameof(record));

        if (record.MemberId <= 0)
            throw new ArgumentException("Member ID must be valid.", nameof(record));

        if (record.DueDate <= record.BorrowDate)
            throw new ArgumentException("Due date must be after borrow date.", nameof(record));
    }
}
