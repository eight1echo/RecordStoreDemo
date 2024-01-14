namespace RecordStoreDemo.Features.Webstore.Products;

public class UpdateWebstoreProductRequest
{
    [Required]
    public long ProductId { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string ProductType { get; set; } = string.Empty;
    public DateTimeOffset? PublishedAt { get; set; }
    [Required]
    public string Status { get; set; } = string.Empty;
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string UPC { get; set; } = string.Empty;
    [Required]
    public decimal Weight { get; set; }
}