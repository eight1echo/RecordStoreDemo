namespace Ardalis.GuardClauses;
public static class RewardsGuard
{
    public static string InvalidCardNumber(this IGuardClause guardClause, string cardNumber, string parameterName)
    {
        if (!string.IsNullOrEmpty(cardNumber))
        {
            if (cardNumber.Length == 9)
            {
                foreach (char c in cardNumber)
                {
                    if (c < '0' || c > '9')
                        throw new ArgumentException($"Card Number must contain only digits 0-9.", parameterName);
                }

                return cardNumber;
            }
        }

        throw new ArgumentException($"Invalid Card Number", parameterName);
    }
}