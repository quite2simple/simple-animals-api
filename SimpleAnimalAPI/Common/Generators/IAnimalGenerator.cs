namespace SimpleAnimalAPI.Common.Generators;

using SimpleAnimalAPI.Modules.Animals;
using SimpleAnimalAPI.Modules.Animals.Contracts;

public interface IAnimalGenerator
{
    public string GetName();
    public IEnumerable<string> GetNames(int count=-1);
    public CreateAnimalDetailedRequest GetPreset();
    public IEnumerable<CreateAnimalDetailedRequest> GetPresets(int count=-1);
    public Animal GetAnimal(CreateAnimalDetailedRequest request);
    public IEnumerable<Animal> GetAnimals(int count=-1);
}