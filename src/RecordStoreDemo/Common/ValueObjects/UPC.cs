namespace RecordStoreDemo.Common.ValueObjects;

public class UPC(string value) : BaseValueObject
{
    public string Value { get; private set; } = Guard.Against.NullOrEmpty(value, nameof(UPC));

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}