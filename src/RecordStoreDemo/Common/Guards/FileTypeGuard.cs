namespace Ardalis.GuardClauses;

public static class FileTypeGuard
{
    public static string InvalidCatalogFile(this IGuardClause guardClause, string fileType, string parameterName)
    {
        var acceptedFiles = new string[] { "csv" };

        if (acceptedFiles.Contains(fileType))
        {
            return fileType;
        }

        throw new ArgumentException($"Only .csv files are accepted.", parameterName);
    }

    public static string InvalidImagePath(this IGuardClause guardClause, string imagePath, string parameterName)
    {
        if (!string.IsNullOrEmpty(imagePath))
        {
            if (!FileTypes.Images.Any(x => imagePath.EndsWith(x, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new ArgumentException($"Only \"jpg\", \"jpeg\", \"png\" are accepted.", parameterName);
            }
        }

        return imagePath;
    }
}