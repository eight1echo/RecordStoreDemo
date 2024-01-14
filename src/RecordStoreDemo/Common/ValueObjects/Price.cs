namespace RecordStoreDemo.Common.ValueObjects;

public class Price(decimal value) : BaseValueObject
{
    public decimal Value { get; private set; } = Guard.Against.Negative(value, nameof(Price));

    public void PriceChange(decimal newPrice)
    {
        Value = Guard.Against.NegativeOrZero(newPrice, nameof(Price));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}