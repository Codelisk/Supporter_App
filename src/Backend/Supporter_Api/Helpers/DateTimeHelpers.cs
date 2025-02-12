namespace Supporter_Api.Helpers
{
    public static class DateTimeHelpers
    {
        public static DateTime Now()
        {
            return DateTime.Now.ToUniversalTime();
        }

        public static bool GreaterOrNull(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return true;
            }

            return dateTime.Value > Now();
        }
    }
}
