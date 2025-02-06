namespace SimpleAnimalAPI.Modules.Animals.Contracts;

public class AnimalDetailedResponse : AnimalResponse
{
    public required int Age { get; set; }
    public required string Species { get; set; }
}