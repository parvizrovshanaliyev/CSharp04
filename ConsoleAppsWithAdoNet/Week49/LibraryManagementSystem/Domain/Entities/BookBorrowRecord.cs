namespace LibraryManagementSystem.Domain.Entities;

/// <summary>
/// Represents a book borrowing record in the library system.
/// Tracks when a member borrows a book and when it should be returned.
/// </summary>
 public class BookBorrowRecord
{
    /// <summary>
    /// Gets or sets the unique identifier for the borrow record.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the ID of the borrowed book.
    /// </summary>
    public int BookId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the member who borrowed the book.
    /// </summary>
    public int MemberId { get; set; }

    /// <summary>
    /// Gets or sets the date when the book was borrowed.
    /// </summary>
    public DateTime BorrowDate { get; set; }

    /// <summary>
    /// Gets or sets the expected return date for the book.
    /// </summary>
    public DateTime DueDate { get; set; }

    /// <summary>
    /// Gets or sets the actual date when the book was returned.
    /// Null if the book has not been returned yet.
    /// </summary>
    public DateTime? ReturnDate { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the book has been returned.
    /// This is stored in the database for query performance.
    /// </summary>
    public bool IsReturned { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the record was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the record was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    // Navigation properties (for in-memory use with Generic Collections)

    /// <summary>
    /// Gets or sets the associated book entity.
    /// </summary>
    public Book? Book { get; set; }

    /// <summary>
    /// Gets or sets the associated member entity.
    /// </summary>
    public Member? Member { get; set; }

    /// <summary>
    /// Gets a value indicating whether the book is overdue.
    /// </summary>
    public bool IsOverdue => !IsReturned && DateTime.Now > DueDate;

    /// <summary>
    /// Gets the number of days the book is overdue.
    /// Returns 0 if not overdue.
    /// </summary>
    public int DaysOverdue => IsOverdue ? (DateTime.Now - DueDate).Days : 0;

    /// <summary>
    /// Returns a string representation of the borrow record.
    /// </summary>
    /// <returns>A formatted string containing borrow record details.</returns>
    public override string ToString()
    {
        var status = IsReturned ? "Returned" : (IsOverdue ? $"Overdue by {DaysOverdue} days" : "Active");
        return $"[{Id}] BookId: {BookId}, MemberId: {MemberId}, Status: {status}";
    }
}
