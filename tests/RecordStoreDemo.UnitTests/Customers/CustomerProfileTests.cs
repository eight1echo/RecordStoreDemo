namespace RecordStoreDemo.UnitTests.Customers;
public class CustomerProfileTests
{
    [Fact]
    public void ShouldDetectPhoneContact()
    {
        var consignorWithPhoneNumber = new CustomerProfile("TestCustomer", "902-222-5555");

        Assert.Null(consignorWithPhoneNumber.EmailAddress);
        Assert.NotNull(consignorWithPhoneNumber.PhoneNumber);
        Assert.Equal(consignorWithPhoneNumber.PhoneNumber.Digits, consignorWithPhoneNumber.GetContact());
    }

    [Fact]
    public void ShouldDetectEmailContact()
    {
        var consignorWithEmail = new CustomerProfile("TestCustomer", "123@abc.ca");

        Assert.Null(consignorWithEmail.PhoneNumber);
        Assert.NotNull(consignorWithEmail.EmailAddress);
        Assert.Equal(consignorWithEmail.EmailAddress.Address, consignorWithEmail.GetContact());
    }
}