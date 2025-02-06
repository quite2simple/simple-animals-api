using SimpleAnimalAPI.Modules.Animals;
using SimpleAnimalAPI.Modules.Animals.Contracts;

namespace SimpleAnimalAPI.Common.Generators;

public class RandomAnimalGenerator : IAnimalGenerator
{
    private readonly Random _random = new Random();
    
    private const int _defaultCount = 1;
    
    private readonly string[] _names = 
    [
        "Brave Lion",
        "Swift Falcon",
        "Clever Fox",
        "Gentle Deer",
        "Fierce Tiger",
        "Playful Dolphin",
        "Wise Owl",
        "Loyal Dog",
        "Graceful Swan",
        "Mighty Elephant",
        "Cunning Wolf",
        "Curious Cat",
        "Majestic Eagle",
        "Jolly Penguin",
        "Silent Snake",
        "Bold Bear",
        "Friendly Rabbit",
        "Proud Peacock",
        "Noble Horse",
        "Shy Turtle"
    ];

    private readonly int _minAge = 0;
    private readonly int _maxAge = 20;

    private readonly (string Species, string Emoji)[] _species =
    [
        ("Cat", "🐱"),
        ("Dog", "🐶"),
        ("Horse", "🐴"),
        ("Elephant", "🐘"),
        ("Giraffe", "🦒"),
        ("Penguin", "🐧"),
        ("Lion", "🦁"),
        ("Falcon", "🦅"),
        ("Fox", "🦊"),
        ("Deer", "🦌"),
        ("Tiger", "🐯"),
        ("Dolphin", "🐬"),
        ("Owl", "🦉"),
        ("Dog", "🐶"),
        ("Swan", "🦢"),
        ("Elephant", "🐘"),
        ("Wolf", "🐺"),
        ("Cat", "🐱"),
        ("Eagle", "🦅"),
        ("Penguin", "🐧"),
        ("Snake", "🐍"),
        ("Bear", "🐻"),
        ("Rabbit", "🐰"),
        ("Peacock", "🦚"),
        ("Horse", "🐴"),
        ("Turtle", "🐢")
    ];
    
    private T RandomArrayElement<T>(T[] array)
    {
        return array[_random.Next(0, array.Length)];
    }

    public string GetName()
    {
        return RandomArrayElement<string>(_names);
    }
    public IEnumerable<string> GetNames(int count=_defaultCount)
    {
        for (int i = 0; i < count; i++)
        {
            yield return GetName();
        }
    }
    
    public CreateAnimalDetailedRequest GetPreset()
    {
        var randomSpecies = RandomArrayElement(_species);
        return new CreateAnimalDetailedRequest
        {
            Name = GetName(),
            Emoji = randomSpecies.Emoji,
            Age = _random.Next(_minAge, _maxAge),
            Species = randomSpecies.Species
        };
    }
    public IEnumerable<CreateAnimalDetailedRequest> GetPresets(int count=_defaultCount)
    {
        for (int i = 0; i < count; i++)
        {
            yield return GetPreset();
        }
    }

    public Animal GetAnimal(CreateAnimalDetailedRequest request)
    {
        return Animal.CreateFromRequest(GetPreset());
    }
    public IEnumerable<Animal> GetAnimals(int count=_defaultCount)
    {
        for (int i = 0; i < count; i++)
        {
            yield return GetAnimal(GetPreset());
        }
    }
}