using System.Data.SqlClient;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Infrastructure.Repositories;

/// <summary>
/// ADO.NET implementation of the book borrow repository.
/// </summary>
public class BookBorrowRepository : IBookBorrowRepository
{
    private readonly string _connectionString;

    public BookBorrowRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<BookBorrowRecord> GetAll()
    {
        var records = new List<BookBorrowRecord>();

        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT * FROM BookBorrowRecords ORDER BY BorrowDate DESC";

        using var command = new SqlCommand(query, connection);
        connection.Open();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            records.Add(MapToRecord(reader));
        }

        return records;
    }

    public BookBorrowRecord? GetById(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT * FROM BookBorrowRecords WHERE Id = @Id";

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);
        connection.Open();

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return MapToRecord(reader);
        }

        return null;
    }

    public int Add(BookBorrowRecord record)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = @"
            INSERT INTO BookBorrowRecords (BookId, MemberId, BorrowDate, DueDate, IsReturned, CreatedAt)
            VALUES (@BookId, @MemberId, @BorrowDate, @DueDate, @IsReturned, @CreatedAt);
            SELECT SCOPE_IDENTITY();";

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@BookId", record.BookId);
        command.Parameters.AddWithValue("@MemberId", record.MemberId);
        command.Parameters.AddWithValue("@BorrowDate", record.BorrowDate);
        command.Parameters.AddWithValue("@DueDate", record.DueDate);
        command.Parameters.AddWithValue("@IsReturned", record.IsReturned);
        command.Parameters.AddWithValue("@CreatedAt", record.CreatedAt);

        connection.Open();
        var result = command.ExecuteScalar();
        return Convert.ToInt32(result);
    }

    public bool Update(BookBorrowRecord record)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = @"
            UPDATE BookBorrowRecords 
            SET BookId = @BookId, MemberId = @MemberId, BorrowDate = @BorrowDate, 
                DueDate = @DueDate, ReturnDate = @ReturnDate, IsReturned = @IsReturned, 
                UpdatedAt = @UpdatedAt
            WHERE Id = @Id";

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", record.Id);
        command.Parameters.AddWithValue("@BookId", record.BookId);
        command.Parameters.AddWithValue("@MemberId", record.MemberId);
        command.Parameters.AddWithValue("@BorrowDate", record.BorrowDate);
        command.Parameters.AddWithValue("@DueDate", record.DueDate);
        command.Parameters.AddWithValue("@ReturnDate", record.ReturnDate ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@IsReturned", record.IsReturned);
        command.Parameters.AddWithValue("@UpdatedAt", record.UpdatedAt ?? (object)DBNull.Value);

        connection.Open();
        return command.ExecuteNonQuery() > 0;
    }

    public bool Delete(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "DELETE FROM BookBorrowRecords WHERE Id = @Id";

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);

        connection.Open();
        return command.ExecuteNonQuery() > 0;
    }

    private BookBorrowRecord MapToRecord(SqlDataReader reader)
    {
        return new BookBorrowRecord
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            BookId = reader.GetInt32(reader.GetOrdinal("BookId")),
            MemberId = reader.GetInt32(reader.GetOrdinal("MemberId")),
            BorrowDate = reader.GetDateTime(reader.GetOrdinal("BorrowDate")),
            DueDate = reader.GetDateTime(reader.GetOrdinal("DueDate")),
            ReturnDate = reader.IsDBNull(reader.GetOrdinal("ReturnDate")) 
                ? null 
                : reader.GetDateTime(reader.GetOrdinal("ReturnDate")),
            IsReturned = reader.GetBoolean(reader.GetOrdinal("IsReturned")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            UpdatedAt = reader.IsDBNull(reader.GetOrdinal("UpdatedAt")) 
                ? null 
                : reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
        };
    }
}
