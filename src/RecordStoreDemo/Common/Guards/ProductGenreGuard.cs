namespace Ardalis.GuardClauses;

public static class ProductGenreGuard
{
    public static string InvalidMusicGenre(this IGuardClause guardClause, string genre, string parameterName)
    {
        if (string.IsNullOrEmpty(genre))
        {
            return genre;
        }
        if (!ProductMetaFields.MusicGenres.Contains(genre))
        {
            throw new ArgumentException($"Invalid Music Genre", parameterName);
        }

        return genre;
    }
}