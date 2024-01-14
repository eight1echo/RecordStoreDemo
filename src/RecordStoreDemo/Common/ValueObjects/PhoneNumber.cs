namespace RecordStoreDemo.Common.ValueObjects;

public class PhoneNumber(string value) : BaseValueObject
{
    public string Digits { get; set; } = Guard.Against.InvalidPhoneNumber(value, nameof(PhoneNumber));

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Digits;
    }
}