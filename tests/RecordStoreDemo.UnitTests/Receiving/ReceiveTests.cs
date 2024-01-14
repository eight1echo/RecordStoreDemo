namespace RecordStoreDemo.UnitTests.Receiving;
public class ReceiveTests
{
    private readonly CatalogProduct _testCatalogProduct;
    private readonly InventoryProduct _testInventoryProduct;
    private readonly Receive _testReceive;
    private readonly Vendor _testVendor;

    public ReceiveTests()
    {
        _testCatalogProduct = new CatalogProduct("TestVendor", "TestArtist", 10.0m, "TestDescription", "CD", "TestLabel", "TestSKU", DateTime.Now, "TestTitle", "1234567890") { Id = Guid.NewGuid() };
        _testInventoryProduct = new InventoryProduct(new Guid(), "TestArtist", "Media", "CD", "Metal", 12.99m, DateTime.Now, "TestProduct", "0123456789") { Id = new Guid() };
        _testVendor = new Vendor("TestVendor") { Id = Guid.NewGuid() };
        _testReceive = new Receive(_testVendor.Id) { Id = Guid.NewGuid() };
    }

    [Fact]
    public void ShouldNotSubmitIfAlreadySubmitted()
    {
        var item = new ReceiveItem(_testReceive.Id, _testInventoryProduct.Id, _testCatalogProduct.Id, 1) { CatalogProduct = _testCatalogProduct, InventoryProduct = _testInventoryProduct };
        _testReceive.AddItem(item);
        _testReceive.Submit();

        Assert.Throws<InvalidOperationException>(_testReceive.Submit);
    }

    [Fact]
    public void ShouldNotSubmitIfNoItems()
    {
        Assert.Throws<InvalidOperationException>(_testReceive.Submit);
    }
}
