using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Validation.Attributes
{
    public class DecimalRangeAttribute : RangeAttribute
    {
        /// <summary>
        /// Minimum possible value of SQL decimal(18, 4).
        /// </summary>
        private const string MinValue = "-99999999999999.9999";

        /// <summary>
        /// Maximum possible value of SQL decimal(18, 4).
        /// </summary>
        private const string MaxValue = "99999999999999.9999";

        public DecimalRangeAttribute()
            : base(typeof(decimal), MinValue, MaxValue)
        {
        }
    }
}
