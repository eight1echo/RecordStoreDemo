namespace RecordStoreDemo.UnitTests.Purchasing;
public class CatalogTests
{
    private readonly Vendor _testVendor;

    public CatalogTests()
    {
        _testVendor = new Vendor("TestVendor");
    }

    [Fact]
    public void ShouldHaveFileNameEqualToVendorName()
    {
        Assert.Equal("TestVendor", _testVendor.Name);
    }

    [Fact]
    public void ShouldOnlyAcceptValidFileTypes()
    {
        _testVendor.Catalog.SetFileType("csv");

        Assert.Throws<ArgumentException>(() => _testVendor.Catalog.SetFileType("123"));
        Assert.Throws<ArgumentException>(() => _testVendor.Catalog.SetFileType("exe"));
        Assert.Throws<ArgumentException>(() => _testVendor.Catalog.SetFileType("py"));
        Assert.Throws<ArgumentException>(() => _testVendor.Catalog.SetFileType(""));

        Assert.True(_testVendor.Catalog.FileType == "csv");
    }

    [Fact]
    public void ShouldRequiredValidColumnPosition()
    {
        var digit = new Dictionary<string, string>()
        {
            { "ArtistColumn", "9" },
        };

        var tooLong = new Dictionary<string, string>()
        {
            { "ArtistColumn", "TooLong" },
        };

        var empty = new Dictionary<string, string>()
        {
            { "ArtistColumn", "" },
        };

        Assert.Throws<ArgumentException>(() => _testVendor.Catalog.SetColumns(digit));
        Assert.Throws<ArgumentException>(() => _testVendor.Catalog.SetColumns(tooLong));
        Assert.Throws<ArgumentException>(() => _testVendor.Catalog.SetColumns(empty));
    }
}
