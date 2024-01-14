namespace RecordStoreDemo.Common.ValueObjects;

public class Category : BaseValueObject
{
    public Category(string department, string format)
    {
        Guard.Against.InvalidCategory(department, format, nameof(Category));

        Department = department;
        Format = format;
    }

    public string Department { get; set; }
    public string Format { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Department;
        yield return Format;
    }
}