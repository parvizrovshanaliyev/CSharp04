using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Application.Interfaces;

/// <summary>
/// Interface for member repository operations.
/// </summary>
public interface IMemberRepository
{
    /// <summary>
    /// Gets all members from the database.
    /// </summary>
    List<Member> GetAll();

    /// <summary>
    /// Gets a member by its unique identifier.
    /// </summary>
    Member? GetById(int id);

    /// <summary>
    /// Adds a new member to the database.
    /// </summary>
    int Add(Member member);

    /// <summary>
    /// Updates an existing member in the database.
    /// </summary>
    bool Update(Member member);

    /// <summary>
    /// Deletes a member from the database.
    /// </summary>
    bool Delete(int id);
}
