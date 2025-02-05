namespace SimpleAnimalAPI.Modules.Animals;

using SimpleAnimalAPI.Modules.Animals.Contracts;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Age { get; set; }
    public string? Species { get; set; }
    public string Emoji { get; set; }
}