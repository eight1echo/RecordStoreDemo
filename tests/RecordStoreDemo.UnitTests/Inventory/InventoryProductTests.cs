namespace RecordStoreDemo.UnitTests.Inventory;
public class InventoryProductTests
{
    private readonly InventoryProduct _testProduct;

    public InventoryProductTests()
    {
        _testProduct = new InventoryProduct(new Guid(), "TestArtist", "Media", "CD", "Metal", 12.99m, DateTime.Now, "TestProduct", "0123456789") { Id = new Guid() };
    }

    [Fact]
    public void CanAdjustOnHand()
    {
        _testProduct.OnHandAdjustment(1, "Testing Inventory");

        Assert.True(_testProduct.OnHand == 1);
    }

    [Fact]
    public void CanChangePrice()
    {
        _testProduct.PriceAdjustment(99.99m, "Testing Price Change");

        Assert.True(_testProduct.Price.Value == 99.99m);
    }

    [Fact]
    public void ShouldSaveInventoryHistory()
    {
        var quantityChange = 1;
        var reason = "Testing Price Change";

        _testProduct.OnHandAdjustment(quantityChange, reason);

        var change = _testProduct.OnHandHistory.FirstOrDefault(c => c.Reason == reason);

        Assert.NotNull(change);
        Assert.True(change.QuantityChange == quantityChange);
        Assert.True(change.Reason == reason);
    }

    [Fact]
    public void ShouldSavePriceHistory()
    {
        var oldPrice = _testProduct.Price.Value;
        var newPrice = 99.99m;
        var reason = "Testing Price Change";

        _testProduct.PriceAdjustment(newPrice, reason);

        var change = _testProduct.PriceHistory.FirstOrDefault(c => c.Reason == reason);

        Assert.NotNull(change);
        Assert.True(change.NewPrice.Value == newPrice);
        Assert.True(change.OldPrice.Value == oldPrice);
        Assert.True(change.Reason == reason);
    }

    [Fact]
    public void ShouldNotChangeInventoryToBelowZero()
    {
        Assert.Throws<InventoryQuantityException>(() => _testProduct.OnHandAdjustment(-11, "Testing Inventory"));
    }
}