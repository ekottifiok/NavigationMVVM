namespace Ch09NavigationMVVM.Models;

public class People
{
    public string? FirstName { get; }
    public string? LastName { get; }

    public People(string? firstName, string? lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}