namespace Ardalis.GuardClauses;

public static class ProductSalePriceGuard
{
    public static void InvalidSalePrice(this IGuardClause guardClause, Price cost, Price salePrice)
    {
        if (salePrice.Value < cost.Value)
        {
            throw new InvalidOperationException($"Sale Price cannot be lower than cost");
        }
    }
}