using System.Globalization;

namespace BankTransactions.Extensions
{
    public static class StringExtensions
    {
        /**
         * Credits: https://stackoverflow.com/a/5057800
         */
        public static string Capitalize(this string str)
        {
            return Thread
                .CurrentThread
                .CurrentCulture
                .TextInfo
                .ToTitleCase(str);
        }

        public static string Capitalize2(this string str)
        {
            string capitalizedString = string.Empty;

            foreach (string splitstring in str.Split())
            {
                capitalizedString += $"{char.ToUpper(splitstring[0]) + splitstring[1..]} ";
            }

            return capitalizedString.Trim();
        }
    }
}
