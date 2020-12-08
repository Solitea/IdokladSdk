using System;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;

namespace IdokladSdk.Validation
{
    public static class NumericSequenceHelper
    {
        public static string DocumentNumberToVariableSymbol(string documentNumber)
        {
            if (string.IsNullOrEmpty(documentNumber))
            {
                return string.Empty;
            }

            string result = string.Empty;
            for (int i = 0; i < documentNumber.Length; i++)
            {
                if (char.IsDigit(documentNumber, i))
                {
                    result += documentNumber[i];
                }
            }

            return TrimLeftZeros(result);
        }

        public static bool HasNumberPlaceholder(string documentFormat)
        {
            var regex = new Regex(@"\{N+?\}");
            return regex.IsMatch(documentFormat);
        }

        public static bool HasRightLength(string numberFormat, int documentNumber)
        {
            string number = NumberGenerator(numberFormat, DateTime.UtcNow, ++documentNumber);
            return number.Length <= Constants.MaxDocumentNumberLength;
        }

        public static string NumberGenerator(string numberFormat, DateTime date, int number)
        {
            string result = ReplaceDateValues(numberFormat, date);

            result = result.Replace("{N}", number.ToString(CultureInfo.InvariantCulture));
            result = result.Replace("{NN}", number.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0'));
            result = result.Replace("{NNN}", number.ToString(CultureInfo.InvariantCulture).PadLeft(3, '0'));
            result = result.Replace("{NNNN}", number.ToString(CultureInfo.InvariantCulture).PadLeft(4, '0'));
            result = result.Replace("{NNNNN}", number.ToString(CultureInfo.InvariantCulture).PadLeft(5, '0'));
            result = result.Replace("{NNNNNN}", number.ToString(CultureInfo.InvariantCulture).PadLeft(6, '0'));
            result = result.Replace("{NNNNNNN}", number.ToString(CultureInfo.InvariantCulture).PadLeft(7, '0'));
            result = result.Replace("{NNNNNNNN}", number.ToString(CultureInfo.InvariantCulture).PadLeft(8, '0'));
            result = result.Replace("{NNNNNNNNN}", number.ToString(CultureInfo.InvariantCulture).PadLeft(9, '0'));
            result = result.Replace("{NNNNNNNNNN}", number.ToString(CultureInfo.InvariantCulture).PadLeft(10, '0'));

            return result;
        }

        public static int ParseNumberFromFormat(string documentNumber, string numberFormat)
        {
            _ = documentNumber ?? throw new ArgumentNullException(nameof(documentNumber));
            numberFormat = ReplaceDateValues(numberFormat, DateTime.UtcNow);

            int leftPosition = numberFormat.IndexOf("{N", StringComparison.Ordinal);
            int rightPosition = numberFormat.IndexOf("N}", StringComparison.Ordinal);
            string number = string.Empty;
            if (documentNumber.Length >= leftPosition + (rightPosition - leftPosition))
            {
                number = documentNumber.Substring(leftPosition, rightPosition - leftPosition);
            }

            _ = int.TryParse(number, out var result);
            return result;
        }

        public static string ReplaceDateValues(string numberFormat, DateTime date)
        {
            string result = numberFormat ?? throw new ArgumentNullException(nameof(numberFormat));

            result = result.Replace("{RR}", date.ToString("yy", CultureInfo.InvariantCulture));
            result = result.Replace("{RRRR}", date.Year.ToString(CultureInfo.InvariantCulture));

            result = result.Replace("{M}", date.Month.ToString(CultureInfo.InvariantCulture));
            result = result.Replace("{MM}", date.Month.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0'));

            result = result.Replace("{D}", date.Day.ToString(CultureInfo.InvariantCulture));
            result = result.Replace("{DD}", date.Day.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0'));

            return result;
        }

        private static string TrimLeftZeros(string result)
        {
            return result.TrimStart('0');
        }
    }
}
