using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Validation.Attributes
{
    internal class ColorAttribute : RegularExpressionAttribute
    {
        public const string InvalidColorMessage = "Color value has to be in hexadecimal format (#rrbbgg or #RRBBGG).";

        public const string RegExpression = @"^#[A-Fa-f0-9]{6}$";

        public ColorAttribute()
            : base(RegExpression)
        {
            ErrorMessage = InvalidColorMessage;
        }
    }
}
