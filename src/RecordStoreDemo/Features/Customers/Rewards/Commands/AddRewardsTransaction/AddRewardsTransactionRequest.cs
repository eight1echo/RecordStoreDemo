namespace RecordStoreDemo.Features.Customers.Rewards.Commands.AddRewardsTransaction;
public class AddRewardsTransactionRequest
{
    [Required]
    public Guid CustomerProfileId { get; set; }
    [Required]
    public string CardNumber { get; set; } = string.Empty;
    [Required]
    public int PointsChange { get; set; }
}