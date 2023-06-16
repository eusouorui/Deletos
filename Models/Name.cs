namespace Deletos.Models;

public class Name
{
    public required string FirstName { get; set; }
    public string? MiddleNames { get; set; }
    public string? LastName { get; set; }

    public Name(string firstName, string? middleNames, string? lastName)
    {
        this.FirstName = firstName;
        this.MiddleNames = middleNames;
        this.LastName = lastName;
    }

    public string GetFullName()
    {
        return FirstName + " " + MiddleNames + " " + LastName;
    }

    public string GetFirstAndLastNames()
    {
        return FirstName + " " + LastName;
    }
}