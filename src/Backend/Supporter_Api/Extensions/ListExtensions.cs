namespace Supporter_Api.Extensions
{
    public static class ListExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T>? source)
        {
            return source == null || !source.Any();
        }

        public static bool AddIfNotNull<T>(this List<T> list, T item)
        {
            if (item is not null)
            {
                list.Add(item);
                return true;
            }
            return false;
        }

        public static IEnumerable<T> AddMissingValues<T>(
            this IEnumerable<T> sourceArray,
            IEnumerable<T> targetArray
        )
            where T : struct
        {
            // Filtere die Werte aus sourceArray, die nicht in targetArray enthalten sind
            var missingValues = sourceArray.Where(x => !targetArray.Contains(x));

            // Kombiniere die fehlenden Werte mit targetArray
            return targetArray.Concat(missingValues);
        }
    }
}
