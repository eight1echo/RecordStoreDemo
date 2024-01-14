namespace RecordStoreDemo.UnitTests.Purchasing;
public class PurchaseOrderTests
{
    private readonly PurchaseOrder _testOrder;
    private readonly CatalogProduct _testProduct;
    private readonly CatalogProduct _testProduct2;

    public PurchaseOrderTests()
    {
        _testOrder = new PurchaseOrder(Guid.NewGuid()) { Id = Guid.NewGuid() };
        _testProduct = new CatalogProduct("TestVendor", "TestArtist", 10.0m, "TestDescription", "CD", "TestLabel", "TestSKU", DateTime.Now, "TestTitle", "1234567890") { Id = Guid.NewGuid() };
        _testProduct2 = new CatalogProduct("TestVendor", "TestArtist", 5.0m, "TestDescription", "CD", "TestLabel", "TestSKU", DateTime.Now, "TestTitle", "1234567890") { Id = Guid.NewGuid() };
    }

    [Fact]
    public void ShouldAdjustCartQuantity()
    {
        var testItem = _testOrder.AddItem(_testProduct, 5);
        _testOrder.RemoveItem(_testProduct.Id);
        Assert.True(testItem.CatalogProduct.CartQuantity == 0);

        var testItem2  =_testOrder.AddItem(_testProduct2, 10);
        testItem2.UpdateQuantity(3);
        Assert.True(testItem2.Quantity == 13);
        Assert.True(testItem2.CatalogProduct.CartQuantity == 13);
    }

    [Fact]
    public void ShouldCalculateTotal()
    {
        var testItem = new PurchaseOrderItem(_testProduct, 5);
        var testItem2 = new PurchaseOrderItem(_testProduct2, 10);

        _testOrder.AddItem(_testProduct, 5);
        _testOrder.AddItem(_testProduct2, 10);
        _testOrder.UpdateItem(testItem2.CatalogProductId, 3);
        _testOrder.RemoveItem(_testProduct.Id);

        Assert.True(_testOrder.Total == 15.0m);
    }

    [Fact]
    public void ShouldNotSubmitIfAlreadySubmitted()
    {
        _testOrder.AddItem(_testProduct, 5);
        _testOrder.Submit();

        Assert.Throws<InvalidOperationException>(_testOrder.Submit);
    }

    [Fact]
    public void ShouldNotSubmitIfNoItems()
    {
        Assert.Throws<InvalidOperationException>(_testOrder.Submit);
    }
}