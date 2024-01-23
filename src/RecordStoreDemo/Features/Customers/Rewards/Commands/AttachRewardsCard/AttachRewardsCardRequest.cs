namespace RecordStoreDemo.Features.Customers.Rewards.Commands.AttachRewardsCard;
public class AttachRewardsCardRequest
{
    [Required]
    public Guid CustomerProfileId { get; set; }
    [Required]
    [Length(9, 9)]
    public string CardNumber { get; set; } = string.Empty;
}