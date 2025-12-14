namespace LibraryManagementSystem.Domain.Entities;

/// <summary>
/// Represents a library member entity.
/// </summary>
public class Member
{
    /// <summary>
    /// Gets or sets the unique identifier for the member.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the first name of the member.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the last name of the member.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address of the member.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number of the member.
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the address of the member.
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date when the member joined the library.
    /// </summary>
    public DateTime MembershipDate { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the member is active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the record was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the record was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Gets the full name of the member by combining first and last name.
    /// </summary>
    public string FullName => $"{FirstName} {LastName}";

    /// <summary>
    /// Returns a string representation of the member.
    /// </summary>
    /// <returns>A formatted string containing member details.</returns>
    public override string ToString()
    {
        return $"[{Id}] {FullName} - Email: {Email} - Active: {(IsActive ? "Yes" : "No")}";
    }
}
