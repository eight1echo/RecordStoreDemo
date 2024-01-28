using System.Globalization;
using System.Text;

namespace RecordStoreDemo.Common;

public static class HelperExtensions
{
    /// <summary>
    /// Takes a string with values separated by commas and returns the values as a List of strings.
    /// </summary>
    public static List<string> ToListFromCommaSeparated(this string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return [];
        }
        else
        {
            return text.Replace(" ", "").Split(',').ToList();
        }
    }

    /// <summary>
    /// Takes a List of strings and returns the values in a single comma separated string.
    /// </summary>
    public static string ToCommaSeparatedFromList(this List<string> list)
    {
        if (list.Count > 0)
        {
            var firstValue = list.First();
            StringBuilder sbValues = new($"{firstValue}");

            list.Remove(firstValue);
            if (list.Count > 0)
            {
                foreach (var value in list)
                {
                    sbValues.Insert(0, $"{value}, ");
                }
            }

            list.Add(firstValue);
            return sbValues.ToString();
        }

        else return string.Empty;
    }

    /// <summary>
    /// Returns a string converted to Title Case, for example "NEIL YOUNG" becomes "Neil Young".
    /// </summary>
    public static string ToTitleCase(this string str)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
    }

    /// <summary>
    /// Reverses an Artist's name to have the surname first, for example "Neil Young" becomes "Young, Neil".
    /// </summary>
    public static string FormatArtistName(this string str)
    {
        var split = str.Split(" ");

        var length = split.Length;

        var newString = split[length - 1] + ",";

        for (int i = 0; i < length - 1; i++)
        {
            newString += " " + split[i];
        }

        return newString;
    }

    /// <summary>
    /// Returns a Rewards Card Number with added spaces for readability. For example "123456789" becomes "123 456 789".
    /// </summary>
    public static string ToSpacedRewardsCard(this string str)
    {
        if (str == string.Empty)
            return "None Attached";

        var cardNumber = $"{str.Substring(0, 3)}  {str.Substring(3, 3)}  {str.Substring(6, 3)}";

        return cardNumber;
    }
}