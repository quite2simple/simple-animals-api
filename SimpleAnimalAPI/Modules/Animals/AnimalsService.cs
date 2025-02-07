namespace SimpleAnimalAPI.Modules.Animals;
using SimpleAnimalAPI.Modules.Animals.Contracts;
using SimpleAnimalAPI.Common.Generators;

public class AnimalsService
{

    private readonly IAnimalGenerator _animalGenerator;

    private List<Animal> _animals;
    
    public AnimalsService(IAnimalGenerator animalGenerator)
    {
        _animals = new List<Animal>();
        _animalGenerator = animalGenerator;
        PopulateAnimals();
    }
    
    private void PopulateAnimals(int count=100)
    {
        _animals = _animalGenerator.GetAnimals(count).ToList();
    }
    
    public Animal Create(CreateAnimalRequest request)
    {
        return Animal.CreateFromRequest(request);
    }

    public AnimalResponse? Get(int id, bool detailed=false)
    {
        var res = _animals.FirstOrDefault(a => a.Id == id);

        if (res == null)
        {
            return null;
        }
        return detailed ? res.ToResponse() : res.ToDetailedResponse();
    }

    public AnimalResponse[] GetList(int start = 0, int end = -1, bool detailed = false)
    {
        if (end == -1)
            end = _animals.Count - 1;
        if (start < 0)
            start = 0;
        if (end > _animals.Count)
            end = _animals.Count - 1;
        
        return _animals.Slice(start, end).Select(a => detailed ? a.ToResponse() : a.ToDetailedResponse()).ToArray();
    }
        
}