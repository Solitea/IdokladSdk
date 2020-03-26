using System;

namespace IdokladSdk.Requests.Core.Extensions
{
    /// <summary>
    /// Extensions for DateTime.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Sets <see cref="DateTime.Kind"/> property to <see cref="DateTimeKind.Utc"/>.
        /// </summary>
        /// <param name="date">DateTime instance whose Kind property is to be set to UTC.</param>
        /// <returns>New DateTime instance with modified Kind property.</returns>
        public static DateTime SetKindUtc(this DateTime date)
        {
            return DateTime.SpecifyKind(date, DateTimeKind.Utc);
        }
    }
}
