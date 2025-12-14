using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Application.Interfaces;

/// <summary>
/// Interface for member service operations.
/// </summary>
public interface IMemberService
{
    /// <summary>
    /// Gets all members.
    /// </summary>
    List<Member> GetAllMembers();

    /// <summary>
    /// Gets a member by its unique identifier.
    /// </summary>
    Member? GetMemberById(int id);

    /// <summary>
    /// Registers a new member.
    /// </summary>
    int AddMember(Member member);

    /// <summary>
    /// Updates an existing member.
    /// </summary>
    bool UpdateMember(Member member);

    /// <summary>
    /// Deletes a member.
    /// </summary>
    bool DeleteMember(int id);
}
