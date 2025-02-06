namespace SimpleAnimalAPI.Modules.Animals;

using SimpleAnimalAPI.Modules.Animals.Contracts;

public class Animal
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int? Age { get; set; }
    public string? Species { get; set; }
    public required string Emoji { get; set; }

    private static int idCounter = 0;

    public Animal()
    {
        Id = ++idCounter;
    }

    public static Animal CreateFromRequest(CreateAnimalRequest request)
    {
        return new Animal
        {
            Name = request.Name,
            Emoji = request.Emoji
        };
    }
    
    public static Animal CreateFromRequest(CreateAnimalDetailedRequest request)
    {
        return new Animal
        {
            Name = request.Name,
            Age = request.Age,
            Species = request.Species,
            Emoji = request.Emoji
        };
    }
    
    public AnimalResponse ToResponse()
    {
        return new AnimalResponse
        {
            Id = Id,
            Name = Name,
            Emoji = Emoji
        };
    }
    
    public AnimalDetailedResponse ToDetailedResponse()
    {
        return new AnimalDetailedResponse
        {
            Id = Id,
            Name = Name,
            Age = Age ?? 0,
            Species = Species,
            Emoji = Emoji
        };
    }
}