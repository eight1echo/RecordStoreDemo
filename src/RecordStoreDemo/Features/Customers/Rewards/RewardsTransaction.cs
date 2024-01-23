namespace RecordStoreDemo.Features.Customers.Rewards;
public class RewardsTransaction : BaseEntity
{
    public RewardsTransaction(int pointsChange)
    {
        Date = DateTime.Now;
        PointsChange = pointsChange;
    }
    public DateTime Date { get; private set; }
    public int PointsChange { get; private set; }
}