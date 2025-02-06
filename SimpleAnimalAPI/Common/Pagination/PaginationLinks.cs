namespace SimpleAnimalAPI.Common.Pagination;

public class PaginationLinks
{
    public required string Current { get; set; }
    public required string? Previous { get; set; }
    public required string? Next { get; set; }
    public required string First { get; set; }
    public required string Last { get; set; }
}