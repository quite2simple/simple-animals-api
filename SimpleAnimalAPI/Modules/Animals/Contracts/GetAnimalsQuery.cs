namespace SimpleAnimalAPI.Modules.Animals.Contracts;

public class GetAnimalsQuery
{
    public int Offset { get; set; } = 0;
    public int Limit { get; set; } = 10;
    public bool Detailed { get; set; } = true;
}