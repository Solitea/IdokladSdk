using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace IdokladSdk.Validation.Attributes
{
    public class DecimalRangeAttribute : RangeAttribute
    {
        /// <summary>
        /// Minimum possible value of SQL decimal(18, 4).
        /// </summary>
        private const decimal MinValue = -99999999999999.9999M;

        /// <summary>
        /// Maximum possible value of SQL decimal(18, 4).
        /// </summary>
        private const decimal MaxValue = 99999999999999.9999M;

        public DecimalRangeAttribute()
            : base(typeof(decimal), MinValue.ToString(CultureInfo.CurrentCulture), MaxValue.ToString(CultureInfo.CurrentCulture))
        {
        }
    }
}
