namespace RecordStoreDemo.Features.Webstore.MetaFields;

public interface IWebstoreMetaFieldService
{
    Task<List<WebstoreMetaFieldModel>> GetProductMetaFields(long productId);
    Task UpdateGenres(WebstoreProductModel product);
    Task UpdateStyles(WebstoreProductModel product);
    Task UpdateTags(WebstoreProductModel product);
}