using System.Data.SqlClient;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Infrastructure.Repositories;

/// <summary>
/// ADO.NET implementation of the book repository.
/// </summary>
public class BookRepository : IBookRepository
{
    private readonly string _connectionString;

    public BookRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Book> GetAll()
    {
        var books = new List<Book>();

        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT * FROM Books ORDER BY Title";

        using var command = new SqlCommand(query, connection);
        connection.Open();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            books.Add(MapToBook(reader));
        }

        return books;
    }

    public Book? GetById(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT * FROM Books WHERE Id = @Id";

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);
        connection.Open();

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return MapToBook(reader);
        }

        return null;
    }

    public int Add(Book book)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = @"
            INSERT INTO Books (Title, Author, ISBN, PublishedYear, Genre, TotalCopies, AvailableCopies, CreatedAt)
            VALUES (@Title, @Author, @ISBN, @PublishedYear, @Genre, @TotalCopies, @AvailableCopies, @CreatedAt);
            SELECT SCOPE_IDENTITY();";

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Title", book.Title);
        command.Parameters.AddWithValue("@Author", book.Author);
        command.Parameters.AddWithValue("@ISBN", book.ISBN);
        command.Parameters.AddWithValue("@PublishedYear", book.PublishedYear);
        command.Parameters.AddWithValue("@Genre", book.Genre);
        command.Parameters.AddWithValue("@TotalCopies", book.TotalCopies);
        command.Parameters.AddWithValue("@AvailableCopies", book.AvailableCopies);
        command.Parameters.AddWithValue("@CreatedAt", book.CreatedAt);

        connection.Open();
        var result = command.ExecuteScalar();
        return Convert.ToInt32(result);
    }

    public bool Update(Book book)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = @"
            UPDATE Books 
            SET Title = @Title, Author = @Author, ISBN = @ISBN, 
                PublishedYear = @PublishedYear, Genre = @Genre, 
                TotalCopies = @TotalCopies, AvailableCopies = @AvailableCopies, 
                UpdatedAt = @UpdatedAt
            WHERE Id = @Id";

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", book.Id);
        command.Parameters.AddWithValue("@Title", book.Title);
        command.Parameters.AddWithValue("@Author", book.Author);
        command.Parameters.AddWithValue("@ISBN", book.ISBN);
        command.Parameters.AddWithValue("@PublishedYear", book.PublishedYear);
        command.Parameters.AddWithValue("@Genre", book.Genre);
        command.Parameters.AddWithValue("@TotalCopies", book.TotalCopies);
        command.Parameters.AddWithValue("@AvailableCopies", book.AvailableCopies);
        command.Parameters.AddWithValue("@UpdatedAt", book.UpdatedAt ?? (object)DBNull.Value);

        connection.Open();
        return command.ExecuteNonQuery() > 0;
    }

    public bool Delete(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "DELETE FROM Books WHERE Id = @Id";

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);

        connection.Open();
        return command.ExecuteNonQuery() > 0;
    }

    private Book MapToBook(SqlDataReader reader)
    {
        return new Book
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            Title = reader.GetString(reader.GetOrdinal("Title")),
            Author = reader.GetString(reader.GetOrdinal("Author")),
            ISBN = reader.GetString(reader.GetOrdinal("ISBN")),
            PublishedYear = reader.GetInt32(reader.GetOrdinal("PublishedYear")),
            Genre = reader.GetString(reader.GetOrdinal("Genre")),
            TotalCopies = reader.GetInt32(reader.GetOrdinal("TotalCopies")),
            AvailableCopies = reader.GetInt32(reader.GetOrdinal("AvailableCopies")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            UpdatedAt = reader.IsDBNull(reader.GetOrdinal("UpdatedAt")) 
                ? null 
                : reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
        };
    }
}
