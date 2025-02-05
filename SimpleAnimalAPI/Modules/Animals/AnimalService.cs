namespace SimpleAnimalAPI.Modules.Animals;
using SimpleAnimalAPI.Modules.Animals.Contracts;

public class AnimalService
{
    private static int idCounter = 0;

    private List<Animal> Animals;
    
    public AnimalService()
    {
        Animals = new List<Animal>();
    }
    
    public Animal Create(CreateAnimalRequest request)
    {
        var animal = new Animal
        {
            Id = ++idCounter,
            Name = request.Name,
            Emoji = request.Emoji
        };
        return animal;
    }
    
    public Animal Create(CreateAnimalDetailedRequest request)
    {
        var animal = new Animal
        {
            Id = ++idCounter,
            Name = request.Name,
            Age = request.Age,
            Species = request.Species,
            Emoji = request.Emoji
        };
        return animal;
    }
    
    
        
}