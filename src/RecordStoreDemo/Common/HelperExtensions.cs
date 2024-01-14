using System.Globalization;
using System.Text;

namespace RecordStoreDemo.Common;

public static class HelperExtensions
{
    public static List<string> ToListFromCommaSeparated(this string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return new List<string>();
        }
        else
        {
            var list = new List<string>();
            var split = text.Split(',');

            foreach (var item in split)
            {
                list.Add(item.Trim());
            }

            return list;
        }
    }

    public static string ToCommaSeparatedFromList(this List<string> list)
    {
        if (list.Any())
        {
            var firstValue = list.First();
            StringBuilder sbValues = new($"{firstValue}");

            list.Remove(firstValue);
            if (list.Any())
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
    public static string ToTitleCase(this string str)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
    }

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
}