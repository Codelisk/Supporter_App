namespace Supporter_Api.Common.Services
{
    public interface IPaginationService
    {
        (List<T> objects, int totalRecords) GetPaginated<T>(
            List<T> list,
            string search = null,
            string searchField = null,
            int page = 1,
            int perPage = 10,
            string sortBy = null,
            string sortOrder = "asc",
            (string, string)[]? additionalSearchFields = null
        );
    }
}
