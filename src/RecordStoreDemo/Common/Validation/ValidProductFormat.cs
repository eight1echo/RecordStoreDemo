namespace RecordStoreDemo.Common.Validation;

public class ValidProductFormat : ValidationAttribute
{
    public static string GetErrorMessage() => $"Format is invalid.";
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var request = (ProductRequest)validationContext.ObjectInstance;

        switch (request.Department)
        {
            case "Apparel":
                if (!ProductCategories.Apparel.Contains(request.Format))
                {
                    return new ValidationResult(GetErrorMessage(), new[] { validationContext.MemberName! });
                }
                break;
            case "Book":
                if (!ProductCategories.Book.Contains(request.Format))
                {
                    return new ValidationResult(GetErrorMessage(), new[] { validationContext.MemberName! });
                }
                break;
            case "Media":
                if (!ProductCategories.Media.Contains(request.Format))
                {
                    return new ValidationResult(GetErrorMessage(), new[] { validationContext.MemberName! });
                }
                break;
            case "Toy":
                if (!ProductCategories.Toy.Contains(request.Format))
                {
                    return new ValidationResult(GetErrorMessage(), new[] { validationContext.MemberName! });
                }
                break;
        }

        return ValidationResult.Success;
    }
}