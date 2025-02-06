using SimpleAnimalAPI.Modules.Animals;
using SimpleAnimalAPI.Modules.Animals.Contracts;

namespace SimpleAnimalAPI.Common.Generators;

public class AnimalGenerator : IAnimalGenerator
{
    public IEnumerable<string> GetNames()
    {
        var names = new string[]
        {
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
        };
        foreach (var name in names)
        {
            yield return name;
        }
    }
    public IEnumerable<CreateAnimalDetailedRequest> GetPresets()
    {
        var presets = new CreateAnimalDetailedRequest[]
        {
            new CreateAnimalDetailedRequest
            {
                Name = "Cat",
                Emoji = "🐱",
                Age = 5,
                Species = "Cat"
            },
            new CreateAnimalDetailedRequest
            {
                Name = "Dog",
                Emoji = "🐶",
                Age = 5,
                Species = "Dog"
            },
            new CreateAnimalDetailedRequest
            {
                Name = "Horse",
                Emoji = "🐴",
                Age = 5,
                Species = "Horse"
            },
            new CreateAnimalDetailedRequest
            {
                Name = "Elephant",
                Emoji = "🐘",
                Age = 5,
                Species = "Elephant"
            },
            new CreateAnimalDetailedRequest
            {
                Name = "Giraffe",
                Emoji = "🦒",
                Age = 5,
                Species = "Giraffe"
            },
            new CreateAnimalDetailedRequest
            {
                Name = "Penguin",
                Emoji = "🐧",
                Age = 5,
                Species = "Penguin"
            },
        };
        foreach (var preset in presets)
        {
            yield return preset;
        }
    }
    public IEnumerable<Animal> GetAnimals(int count)
    {
        /* TODO: fix that if count is larger that presets length,
         * less than count of animals will be returned,
         * implement name assigning */
        var presets = GetPresets().Take(count);
        foreach (var preset in presets)
        {
            yield return Animal.CreateFromRequest(preset);
        }
    }
}