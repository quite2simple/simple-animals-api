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
        return detailed ? res.ToDetailedResponse() : res.ToResponse();
    }

    public AnimalResponse[] GetList(int start = 0, int limit = -1, bool detailed = false)
    {
        if (limit == -1)
            limit = 1;
        if (start < 0)
            start = 0;
        if (start + limit > _animals.Count)
            limit = _animals.Count - start;
        
        return _animals.Slice(start, limit).Select(a => detailed ? a.ToDetailedResponse() : a.ToResponse()).ToArray();
    }
        
}