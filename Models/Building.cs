namespace Deletos.Models;

public class Building
{
    public required Adress Adress { get; set; }
    public required int YearOfConstruction;
    public required int NumberOfFloors { get; set; }
    public required float TotalArea { get; set; }
    //Key represents floor number, value represents floor area
    public Dictionary<int, float>? FloorsArea { get; set; }
}