namespace RecordStoreDemo.Features.Receiving;

public class ReceiveModel
{
    public Guid Id { get; set; }
    public Guid VendorId { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateSubmitted { get; set; }
    public ReceiveStatus Status { get; set; }
    public int TotalItems { get; set; }

    public List<ReceiveItemModel> Items { get; set; } = [];
}