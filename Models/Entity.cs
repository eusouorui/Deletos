namespace Deletos.Models;

public class Entity
{
    public required Name Name;
    public DateTime BirthDate { get; set; }

    public Entity(Name name, DateTime birthdate)
    {
        this.Name = name;
        this.BirthDate = birthdate;
    }

    public int GetAge()
    {
        var age = DateTime.Today.Year - BirthDate.Year;

        return BirthDate.Date > DateTime.Today.AddYears(-age) ? --age : age;
    }
}