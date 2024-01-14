namespace RecordStoreDemo.Features.Inventory.Products.Commands.UpdateProductDetails;
public class UpdateProductDetailsRequest : ProductRequest
{
    [Required]
    public Guid InventoryProductId { get; set; }
}