namespace RecordStoreDemo.Features.Inventory.Products.Commands.UpdateProductOnHand;
public class UpdateProductOnHandRequest
{
    [Required]
    public Guid ProductId { get; set; }
    [Required]
    public int QuantityChange { get; set; }
    [Required]
    public string Reason { get; set; } = string.Empty;
}