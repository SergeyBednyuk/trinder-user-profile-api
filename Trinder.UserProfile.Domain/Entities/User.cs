namespace Trinder.UserProfile.Domain.Entities;

public class User(string firstName, string lastName, DateOnly birthDate)
{
    public Guid Id { get; set; }
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;
    public DateOnly BirthDate { get; } = birthDate;
    public string? Nationality { get; set; }
}
