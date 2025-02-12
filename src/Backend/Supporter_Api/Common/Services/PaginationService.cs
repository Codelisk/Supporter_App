using System.Linq.Expressions;
using System.Reflection;

namespace Supporter_Api.Common.Services
{
    public class PaginationService : IPaginationService
    {
        public (List<T> objects, int totalRecords) GetPaginated<T>(
            List<T> list,
            string search = null,
            string searchField = null,
            int page = 1,
            int perPage = 10,
            string sortBy = null,
            string sortOrder = "asc",
            (string, string)[]? additionalSearchFields = null
        )
        {
            var query = list.AsQueryable();

            // Filter (Suche nach Gemeinde oder anderen Feldern)
            if (!string.IsNullOrEmpty(search))
            {
                query = ApplySearch(query, searchField, search);
            }
            if (additionalSearchFields is not null)
            {
                foreach (var additionalField in additionalSearchFields)
                {
                    query = ApplySearch(query, additionalField.Item1, additionalField.Item2);
                }
            }

            var totalRecords = query.Count();

            // Sortierung
            if (!string.IsNullOrEmpty(sortBy))
            {
                query = ApplySorting(query, sortBy, sortOrder);
            }

            // Paginierung
            var users = query.Skip((page - 1) * perPage).Take(perPage).ToList();

            return (users, totalRecords);
        }

        private IQueryable<T> ApplySearch<T>(IQueryable<T> query, string searchField, string searchValue)
        {
            var property = typeof(T).GetProperty(searchField, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (property == null)
                throw new ArgumentException($"Property '{searchField}' not found on type '{typeof(T).Name}'");

            // Erstellen eines Lambda-Ausdrucks für dynamische Filterung
            var parameter = Expression.Parameter(typeof(T), "x");
            var member = Expression.Property(parameter, property.Name);
            Expression containsExpression;

            // Prüfen, ob die Eigenschaft ein String oder Guid ist
            if (property.PropertyType == typeof(string))
            {
                var constant = Expression.Constant(searchValue);
                var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                containsExpression = Expression.Call(member, containsMethod, constant);
            }
            else if (property.PropertyType == typeof(Guid))
            {
                if (Guid.TryParse(searchValue, out var guidValue))
                {
                    var constant = Expression.Constant(guidValue);
                    containsExpression = Expression.Equal(member, constant); // Vergleich auf Gleichheit
                }
                else
                {
                    throw new ArgumentException($"Invalid Guid value: '{searchValue}'");
                }
            }
            else
            {
                throw new NotSupportedException($"Search is not supported for type '{property.PropertyType.Name}'");
            }

            var lambda = Expression.Lambda<Func<T, bool>>(containsExpression, parameter);

            return query.Where(lambda);
        }

        private IQueryable<T> ApplySorting<T>(IQueryable<T> query, string sortBy, string sortOrder)
        {
            var property = typeof(T).GetProperty(sortBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (property == null)
                throw new ArgumentException($"Property '{sortBy}' not found on type '{nameof(T)}'");

            if (sortOrder.ToLower() == "desc")
            {
                return query.OrderByDescending(x => property.GetValue(x, null));
            }
            else
            {
                return query.OrderBy(x => property.GetValue(x, null));
            }
        }
    }
