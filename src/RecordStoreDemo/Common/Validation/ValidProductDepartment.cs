namespace RecordStoreDemo.Common.Validation;

public class ValidProductDepartment : ValidationAttribute
{
    public static string GetErrorMessage() => $"Department is invalid.";
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
            return new ValidationResult("Department field is required.");

        var department = value.ToString()
            ?? throw new ArgumentNullException(nameof(value));

        if (!ProductCategories.Departments.Contains(department))
        {
            return new ValidationResult(GetErrorMessage());
        }

        return ValidationResult.Success;
    }
}