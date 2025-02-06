namespace SimpleAnimalAPI.Common.Generators;

using SimpleAnimalAPI.Modules.Animals;
using SimpleAnimalAPI.Modules.Animals.Contracts;

public interface IAnimalGenerator
{
    
    public IEnumerable<string> GetNames();
    public IEnumerable<CreateAnimalDetailedRequest> GetPresets();
    public IEnumerable<Animal> GetAnimals();
}