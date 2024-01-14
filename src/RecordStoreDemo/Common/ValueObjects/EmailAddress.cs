namespace RecordStoreDemo.Common.ValueObjects;

public class EmailAddress(string value) : BaseValueObject
{
    public string Address { get; set; } = Guard.Against.InvalidEmail(value, nameof(EmailAddress));

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Address;
    }
}