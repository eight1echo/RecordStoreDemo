namespace RecordStoreDemo.Features.Webstore.Products;
public class WebstoreProductModel
{
    public long Id { get; set; }
    public WebstoreProductVariantModel Variant { get; set; } = new();

    public string ImagePath { get; set; } = string.Empty;
    public string ProductType { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public List<string> Genres { get; set; } = [];
    public List<string> Styles { get; set; } = [];
    public List<string> Tags { get; set; } = [];

    public DateTimeOffset? PublishedAt { get; set; }
}