namespace RecordStoreDemo.Features.Inventory.Products.Commands.CreateInventoryProduct;

public class CreateInventoryProductRequest : ProductRequest
{
    [Required]
    public Guid CatalogProductId { get; set; }

    public decimal Price { get; set; }
}