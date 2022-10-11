using System.Globalization;

namespace BankTransactions.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string str)
        {
            string delimiter = " ";
            TextInfo textInfo = new CultureInfo("en-GB", false).TextInfo;

            return string
                .Join(delimiter, str.Split(delimiter)
                .Select(word => textInfo.ToTitleCase(word))
                .ToArray())
                .Trim();
        }
    }

    /*
    public static string Capitalize(this string str)
    {
        string capitalizedString = string.Empty;

        foreach (string splitstring in str.Split())
        {
            capitalizedString += $"{char.ToUpper(splitstring[0]) + splitstring[1..]} ";
        }

        return capitalizedString.Trim();
    }
    */
}
