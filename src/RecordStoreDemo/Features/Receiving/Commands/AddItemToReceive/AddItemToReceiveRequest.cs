using RecordStoreDemo.Features.Inventory.Products.Commands.UpdateProductDetails;

namespace RecordStoreDemo.Features.Receiving.Commands.AddItemToReceive;

public class AddItemToReceiveRequest
{
    [Required]
    public Guid ReceiveId { get; set; }
    [Required]
    public Guid CatalogProductId { get; set; }
    [Required]
    public Guid InventoryProductId { get; set; }
    [Required]
    public UpdateProductDetailsRequest UpdateRequest { get; set; } = new();
    [Required]
    public int Quantity { get; set; } = 1;
    [Required]
    [MinLength(1)]
    public string UPC { get; set; } = string.Empty;
}