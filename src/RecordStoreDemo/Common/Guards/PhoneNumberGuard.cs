using System.Text.RegularExpressions;

namespace Ardalis.GuardClauses;
public static partial class PhoneNumberGuard
{
    public static string InvalidPhoneNumber(this IGuardClause guardClause, string number, string parameterName)
    {
        var match = MyRegex().Match(number);

        if (match.Success)
        {
            return number;
        }

        throw new ArgumentException($"Phone Number format must be ###-###-####", parameterName);
    }

    [GeneratedRegex("^\\d{3}-\\d{3}-\\d{4}$")]
    private static partial Regex MyRegex();
}