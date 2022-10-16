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
    }
}