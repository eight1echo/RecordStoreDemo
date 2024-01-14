namespace RecordStoreDemo.Features.Webstore.Products.Images;

public class UpdateWebstoreImageRequest
{
    public long ProductId { get; set; }
    public string ImagePath { get; set; } = string.Empty;
}
