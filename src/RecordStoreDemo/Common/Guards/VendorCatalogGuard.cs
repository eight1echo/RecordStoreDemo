namespace Ardalis.GuardClauses;

public static class VendorCatalogGuard
{
    public static string InvalidColumnPosition(this IGuardClause guardClause, string column, string parameterName)
    {
        string pattern = @"^[A-Z]{1,1}$";
        Match match = Regex.Match(column, pattern);

        if (match.Success || column == "N/A")
        {
            return column;
        }

        throw new ArgumentException($"??", parameterName);
    }
}