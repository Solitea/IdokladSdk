using System;
using System.Globalization;
using System.Text.RegularExpressions;
using IdokladSdk.Enums;

namespace IdokladSdk.Validation
{
    public class IdentificationNumberHelper
    {
        public static IdentificationValidationResult IdentificationNumberValidation(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return IdentificationValidationResult.NoValue;
            }

            if (!Regex.IsMatch(input, "^[0-9]{8}$"))
            {
                return IdentificationValidationResult.BadFormat;
            }

            int[] weights = {2, 3, 4, 5, 6, 7, 8};
            int result = (11 - WeightedModulo(SubstringSafe(0, 7, input), weights, 11)) % 10;
            return string.Equals(result.ToString(CultureInfo.InvariantCulture), SubstringSafe(7, 1, input))
                ? IdentificationValidationResult.Ok
                : IdentificationValidationResult.CheckFailed;
        }

        private static string SubstringSafe(int startIndex, int length, string text)
        {
            startIndex = startIndex < 0 ? 0 : startIndex;
            length = length < 0 ? 0 : length;

            startIndex = startIndex > text.Length ? text.Length : startIndex;

            if (length > text.Length - startIndex)
            {
                length = text.Length - startIndex;
            }

            return text.Substring(startIndex, length);
        }

        private static int WeightedModulo(string input, int[] weights, int mod)
        {
            if (mod == 0)
            {
                return -1;
            }

            var digits = input.ToCharArray();
            int min = Math.Min(digits.Length, weights.Length);

            if (min == 0)
            {
                return -1;
            }

            Array.Reverse(digits);

            int sum = 0;
            for (byte i = 0; i < min; i++)
            {
                sum += (digits[i] - 48) * weights[i];
            }

            return sum % mod;
        }
    }
}
