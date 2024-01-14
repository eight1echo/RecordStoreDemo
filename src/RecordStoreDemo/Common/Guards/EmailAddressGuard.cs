namespace Ardalis.GuardClauses;
public static class EmailAddressGuard
{
    public static string InvalidEmail(this IGuardClause guardClause, string email, string parameterName)
    {
        if (email.Contains('@'))
        {
            var splitEmail = email.Split("@");
            if (splitEmail[0].Length > 0 && splitEmail[1].Length > 0)
            {
                return email;
            }
        }

        throw new ArgumentException($"Invalid Email Address", parameterName);
    }
}