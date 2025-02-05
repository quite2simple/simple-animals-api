namespace SimpleAnimalAPI.Modules.Animals.Contracts;

public class PaginatedAnimalsResponse
{
    public DateTime Timestamp { get; set; }
    public bool AnimalsDetailed { get; set; }
    public int TotalCount { get; set; }
    public int Offset { get; set; }
    public List<AnimalResponse> Animals { get; set; }
    public string? Next { get; set; }
    public string? Previous { get; set; }
}