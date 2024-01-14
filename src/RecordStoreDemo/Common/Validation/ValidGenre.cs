namespace RecordStoreDemo.Common.Validation;

public class ValidMusicGenre : ValidationAttribute
{
    public static string GetErrorMessage() => $"Genre is invalid.";
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not null)
        {
            var genre = value.ToString();

            if (genre is null)
            {
                return new ValidationResult(GetErrorMessage(), new[] { validationContext.MemberName! });
            }

            if (ProductMetaFields.MusicGenres.Contains(genre) || genre == string.Empty)
            {
                return ValidationResult.Success;
            }
        }

        return new ValidationResult(GetErrorMessage(), new[] { validationContext.MemberName! });
    }
}