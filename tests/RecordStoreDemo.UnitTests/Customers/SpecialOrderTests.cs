namespace RecordStoreDemo.UnitTests.Customers;
public class SpecialOrderTests
{
    private readonly CustomerProfile _testCustomer;
    private readonly InventoryProduct _testProduct;

    public SpecialOrderTests()
    {
        _testCustomer = new CustomerProfile("TestCustomer", "Test@Contact.ca");
        _testProduct = new InventoryProduct(new Guid(), "TestArtist", "Media", "CD", "Metal", 12.99m, DateTime.Now, "TestProduct", "0123456789") { Id = new Guid() };
    }

    [Fact]
    public void CanAddSpecialOrder()
    {
        _testCustomer.AddSpecialOrder(_testProduct.Id);

        Assert.True(_testCustomer.SpecialOrders.Count == 1);
    }
}