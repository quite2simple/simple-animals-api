namespace SimpleAnimalAPI.Modules.Animals.Contracts;

public class AnimalResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Emoji { get; set; }
}