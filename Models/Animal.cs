namespace Deletos.Models.Animal;

public abstract class Animal : Entity
{
    public Animal(Name name, DateTime birthDate, int phoneNumber) : base(name, birthDate)
    {

    }

    protected abstract string GetSound();
}