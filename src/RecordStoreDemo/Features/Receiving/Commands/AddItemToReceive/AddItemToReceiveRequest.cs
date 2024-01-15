using RecordStoreDemo.Features.Inventory.Products.Commands.UpdateProductDetails;

namespace RecordStoreDemo.Features.Receiving.Commands.AddItemToReceive;

public class AddItemToReceiveRequest
{
    [Required]
    public Guid ReceiveId { get; set; }
    [Required]
    public Guid InventoryProductId { get; set; }
    [Required]
    public InventoryProductModel Product { get; set; } = new();
    [Required]
    public int Quantity { get; set; } = 1;
    [Required]
    [MinLength(1)]
    public string UPC { get; set; } = string.Empty;
}