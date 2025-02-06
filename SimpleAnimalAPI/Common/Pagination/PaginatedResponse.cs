namespace SimpleAnimalAPI.Common.Pagination;

public class PaginatedResponse<T>
{
    public List<T> Data { get; set; } = new List<T>();
    public required PaginationMetadata Metadata { get; set; }
    public required PaginationLinks Links { get; set; }
}