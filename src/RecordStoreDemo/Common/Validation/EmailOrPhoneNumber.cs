namespace RecordStoreDemo.Common.Validation;
public partial class EmailOrPhoneNumber : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null) return new ValidationResult("Contact field is required.");
        var contact = value.ToString() ?? throw new ArgumentNullException(nameof(value));

        if (contact.Contains('@'))
        {
            var splitAt = contact.Split("@");
            if (splitAt[0].Length > 0 && splitAt[1].Length > 0)
            {
                if (splitAt[1].Contains('.'))
                {
                    var splitDot = splitAt[1].Split('.');
                    if (splitDot[0].Length > 0 && splitDot[1].Length > 0)
                    {
                        return ValidationResult.Success;
                    }
                }
            }
            return new ValidationResult("Invalid Email Address.", new[] { validationContext.MemberName! });
        }
        else
        {
            var match = MyRegex().Match(contact);

            if (match.Success)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid Contact information.", new[] { validationContext.MemberName! });
        }
    }

    [GeneratedRegex("^\\d{3}-\\d{3}-\\d{4}$")]
    private static partial Regex MyRegex();
}