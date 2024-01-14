using RecordStoreDemo.External.DataSources;

namespace RecordStoreDemo.Features.Webstore.Products.Images;

public interface IWebstoreImageService
{
    Task<List<ImageModel>> FindImages(WebQuery query);
    Task UpdateImage(UpdateWebstoreImageRequest request);
}