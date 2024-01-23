namespace RecordStoreDemo.UnitTests.Customers;
public class RewardsTests
{
    private readonly CustomerProfile _testCustomer;

    public RewardsTests()
    {
        _testCustomer = new CustomerProfile("TestCustomer", "Test@Contact.ca");
    }

    [Fact]
    public void CanAttachRewardsCard()
    {
        var cardNumber = "111222333";
        _testCustomer.AttachRewardsCard(cardNumber);

        Assert.True(_testCustomer.RewardsCard.Number == cardNumber);
    }

    [Fact]
    public void ShouldGuardAgainstInvalidCardNumbers()
    {
        var tooShort = "111";
        var tooLong = "111222333444";
        var includesNonDigits = "abc1234$6";

        Assert.Throws<ArgumentException>(() => _testCustomer.AttachRewardsCard(tooShort));
        Assert.Throws<ArgumentException>(() => _testCustomer.AttachRewardsCard(tooLong));
        Assert.Throws<ArgumentException>(() => _testCustomer.AttachRewardsCard(includesNonDigits));
    }

    [Fact]
    public void CanAddPointsTransaction()
    {
        var cardNumber = "111222333";
        _testCustomer.AttachRewardsCard(cardNumber);
        _testCustomer.RewardsCard.AddTransaction(cardNumber, 1000);

        Assert.True(_testCustomer.RewardsCard.Transactions.Count == 1);
        Assert.True(_testCustomer.RewardsCard.Points == 1000);
    }

    [Fact]
    public void TransactionShouldRequireMatchingCardNumber()
    {
        var cardNumber = "111222333";
        _testCustomer.AttachRewardsCard(cardNumber);        

        Assert.Throws<InvalidOperationException>(() => _testCustomer.RewardsCard.AddTransaction("333222111", 1000));
    }
}
