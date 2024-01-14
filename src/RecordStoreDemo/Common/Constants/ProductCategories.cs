namespace RecordStoreDemo.Common.Constants;

public static class ProductCategories
{
    public static readonly List<string> Departments = new()
    {
        "Apparel", "Book", "Media", "Toy"
    };

    public static readonly List<string> Apparel = new()
    {
        "T-Shirt",
        "Hoodie",
        "Other"
    };

    public static readonly List<string> Book = new()
    {
        "Graphic Novel",
        "Fiction",
        "Non-Fiction",
        "Other"
    };

    public static readonly List<string> Media = new()
    {
        "LP",
        "12\"",
        "10\"",
        "7\"",
        "CD",
        "CASS",
        "DVD",
        "BLU",
        "Other"
    };

    public static readonly List<string> Toy = new()
    {
        "Funko! Pop",
        "Action Figure"
    };
}
