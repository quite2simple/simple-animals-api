namespace SimpleAnimalAPI.Modules.Animals;
using SimpleAnimalAPI.Modules.Animals.Contracts;

public class AnimalService
{
    private int pageSize = 25;

    private List<Animal> Animals;
    
    public AnimalService()
    {
        Animals = new List<Animal>();
    }
    
    public Animal Create(CreateAnimalRequest request)
    {
        return Animal.CreateFromRequest(request);
    }

    public AnimalResponse? Get(int id, bool detailed=false)
    {
        var res = Animals.FirstOrDefault(a => a.Id == id);

        if (res == null)
        {
            return null;
        }
        return detailed ? res.ToResponse() : res.ToDetailedResponse();
    }
    
    
        
}