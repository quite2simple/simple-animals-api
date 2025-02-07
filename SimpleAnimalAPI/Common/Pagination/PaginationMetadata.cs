namespace SimpleAnimalAPI.Common.Pagination;

public class PaginationMetadata
{
    public required int TotalCount { get; set; }
    public required int Offset { get; set; }
}