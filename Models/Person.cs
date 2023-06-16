using Deletos.Models;

namespace Deletos.Models;

public class Person : Entity
{
    public int PhoneNumber { get; set; }

    public Person(Name name, DateTime birthDate, int phoneNumber) : base(name, birthDate)
    {
        this.PhoneNumber = phoneNumber;
    }

}