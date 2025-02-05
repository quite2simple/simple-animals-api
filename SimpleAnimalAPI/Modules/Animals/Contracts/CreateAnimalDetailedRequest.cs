namespace SimpleAnimalAPI.Modules.Animals.Contracts;

public class CreateAnimalDetailedRequest : CreateAnimalRequest
{
    public int Age { get; set; }
    public string Species { get; set; }
}