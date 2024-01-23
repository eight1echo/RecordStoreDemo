namespace RecordStoreDemo.Features.Customers.Rewards;
public class RewardsCardModel
{
    public Guid Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public int Points { get; set; }
    public List<RewardsTransactionModel> Transactions { get; set; } = [];
}