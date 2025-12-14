using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Application.Interfaces;

/// <summary>
/// Interface for book borrow service operations.
/// </summary>
public interface IBookBorrowService
{
    /// <summary>
    /// Gets all borrow records.
    /// </summary>
    List<BookBorrowRecord> GetAllBorrows();

    /// <summary>
    /// Gets a borrow record by its unique identifier.
    /// </summary>
    BookBorrowRecord? GetBorrowById(int id);

    /// <summary>
    /// Adds a new borrow record.
    /// </summary>
    int AddBorrow(BookBorrowRecord record);

    /// <summary>
    /// Updates an existing borrow record.
    /// </summary>
    bool UpdateBorrow(BookBorrowRecord record);

    /// <summary>
    /// Deletes a borrow record.
    /// </summary>
    bool DeleteBorrow(int id);
}
