namespace Ardalis.GuardClauses;

public static class ProductCategoryGuard
{
    public static void InvalidCategory(this IGuardClause guardClause, string department, string format, string parameterName)
    {
        if (!ProductCategories.Departments.Contains(department))
        {
            throw new ArgumentException($"Invalid Department", parameterName);
        }

        switch (department)
        {
            case "Apparel":
                if (!ProductCategories.Apparel.Contains(format))
                {
                    throw new ArgumentException($"Invalid Format", parameterName);
                }
                break;

            case "Book":
                if (!ProductCategories.Book.Contains(format))
                {
                    throw new ArgumentException($"Invalid Format", parameterName);

                }
                break;

            case "Media":
                if (!ProductCategories.Media.Contains(format))
                {
                    throw new ArgumentException($"Invalid Format", parameterName);

                }
                break;

            case "Toy":
                if (!ProductCategories.Toy.Contains(format))
                {
                    throw new ArgumentException($"Invalid Format", parameterName);

                }
                break;

        }
    }
}
