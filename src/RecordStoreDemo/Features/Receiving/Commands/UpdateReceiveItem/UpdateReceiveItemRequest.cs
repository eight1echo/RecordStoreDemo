namespace RecordStoreDemo.Features.Receiving.Commands.UpdateReceiveItem;

public class UpdateReceiveItemRequest
{
    [Required]
    public Guid ReceiveId { get; set; }
    [Required]
    public Guid InventoryProductId { get; set; }
    [Required]
    public int NewQuantity { get; set; }
}