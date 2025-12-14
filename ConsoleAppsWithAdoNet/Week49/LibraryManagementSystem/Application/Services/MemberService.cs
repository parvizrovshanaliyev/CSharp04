using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Application.Services;

/// <summary>
/// Service class for member-related business logic.
/// </summary>
public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;

    public MemberService(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public List<Member> GetAllMembers()
    {
        return _memberRepository.GetAll();
    }

    public Member? GetMemberById(int id)
    {
        return _memberRepository.GetById(id);
    }

    public int AddMember(Member member)
    {
        ValidateMember(member);

        member.CreatedAt = DateTime.Now;
        member.MembershipDate = DateTime.Now;
        member.IsActive = true;

        return _memberRepository.Add(member);
    }

    public bool UpdateMember(Member member)
    {
        ValidateMember(member);

        var existingMember = _memberRepository.GetById(member.Id);
        if (existingMember == null)
            throw new InvalidOperationException($"Member with ID {member.Id} not found.");

        member.UpdatedAt = DateTime.Now;

        return _memberRepository.Update(member);
    }

    public bool DeleteMember(int id)
    {
        var member = _memberRepository.GetById(id);
        if (member == null)
            throw new InvalidOperationException($"Member with ID {id} not found.");

        return _memberRepository.Delete(id);
    }

    private void ValidateMember(Member member)
    {
        if (string.IsNullOrWhiteSpace(member.FirstName))
            throw new ArgumentException("First name cannot be empty.", nameof(member));

        if (string.IsNullOrWhiteSpace(member.LastName))
            throw new ArgumentException("Last name cannot be empty.", nameof(member));

        if (string.IsNullOrWhiteSpace(member.Email))
            throw new ArgumentException("Email cannot be empty.", nameof(member));

        // Simple email validation
        if (!member.Email.Contains("@") || !member.Email.Contains("."))
            throw new ArgumentException("Invalid email format.", nameof(member));
    }
}
