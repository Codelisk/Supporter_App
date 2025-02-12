namespace Supporter_Api.Models
{
    public record PaginateResult<T>(List<T> Objects, int TotalRecords);
}
