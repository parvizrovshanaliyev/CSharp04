using System.Data.SqlClient;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Infrastructure.Repositories;

/// <summary>
/// ADO.NET implementation of the member repository.
/// </summary>
public class MemberRepository : IMemberRepository
{
    private readonly string _connectionString;

    public MemberRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Member> GetAll()
    {
        var members = new List<Member>();

        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT * FROM Members ORDER BY LastName, FirstName";

        using var command = new SqlCommand(query, connection);
        connection.Open();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            members.Add(MapToMember(reader));
        }

        return members;
    }

    public Member? GetById(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT * FROM Members WHERE Id = @Id";

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);
        connection.Open();

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return MapToMember(reader);
        }

        return null;
    }

    public int Add(Member member)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = @"
            INSERT INTO Members (FirstName, LastName, Email, Phone, Address, MembershipDate, IsActive, CreatedAt)
            VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @MembershipDate, @IsActive, @CreatedAt);
            SELECT SCOPE_IDENTITY();";

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@FirstName", member.FirstName);
        command.Parameters.AddWithValue("@LastName", member.LastName);
        command.Parameters.AddWithValue("@Email", member.Email);
        command.Parameters.AddWithValue("@Phone", member.Phone ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@Address", member.Address ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@MembershipDate", member.MembershipDate);
        command.Parameters.AddWithValue("@IsActive", member.IsActive);
        command.Parameters.AddWithValue("@CreatedAt", member.CreatedAt);

        connection.Open();
        var result = command.ExecuteScalar();
        return Convert.ToInt32(result);
    }

    public bool Update(Member member)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = @"
            UPDATE Members 
            SET FirstName = @FirstName, LastName = @LastName, Email = @Email, 
                Phone = @Phone, Address = @Address, IsActive = @IsActive, 
                UpdatedAt = @UpdatedAt
            WHERE Id = @Id";

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", member.Id);
        command.Parameters.AddWithValue("@FirstName", member.FirstName);
        command.Parameters.AddWithValue("@LastName", member.LastName);
        command.Parameters.AddWithValue("@Email", member.Email);
        command.Parameters.AddWithValue("@Phone", member.Phone ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@Address", member.Address ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@IsActive", member.IsActive);
        command.Parameters.AddWithValue("@UpdatedAt", member.UpdatedAt ?? (object)DBNull.Value);

        connection.Open();
        return command.ExecuteNonQuery() > 0;
    }

    public bool Delete(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "DELETE FROM Members WHERE Id = @Id";

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);

        connection.Open();
        return command.ExecuteNonQuery() > 0;
    }

    private Member MapToMember(SqlDataReader reader)
    {
        return new Member
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
            LastName = reader.GetString(reader.GetOrdinal("LastName")),
            Email = reader.GetString(reader.GetOrdinal("Email")),
            Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) 
                ? string.Empty 
                : reader.GetString(reader.GetOrdinal("Phone")),
            Address = reader.IsDBNull(reader.GetOrdinal("Address")) 
                ? string.Empty 
                : reader.GetString(reader.GetOrdinal("Address")),
            MembershipDate = reader.GetDateTime(reader.GetOrdinal("MembershipDate")),
            IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            UpdatedAt = reader.IsDBNull(reader.GetOrdinal("UpdatedAt")) 
                ? null 
                : reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
        };
    }
}
