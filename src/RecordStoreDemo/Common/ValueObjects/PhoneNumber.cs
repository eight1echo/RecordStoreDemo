namespace RecordStoreDemo.Common.ValueObjects;

public class PhoneNumber : BaseValueObject
{
    public PhoneNumber(string value)
    {
        Digits = Guard.Against.InvalidPhoneNumber(value, nameof(Digits));
    }

    public string Digits { get; set; } = null!;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Digits;
    }

    private PhoneNumber() { } // Required for EF
}