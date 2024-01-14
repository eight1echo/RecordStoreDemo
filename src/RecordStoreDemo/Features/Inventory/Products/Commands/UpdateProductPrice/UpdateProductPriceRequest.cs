namespace RecordStoreDemo.Features.Inventory.Products.Commands.UpdateProductPrice;
public class UpdateProductPriceRequest
{
    [Required]
    public Guid ProductId { get; set; }
    [Required]
    public decimal NewPrice { get; set; }
    [Required]
    public string Reason { get; set; } = string.Empty;
}