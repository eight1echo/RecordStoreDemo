namespace RecordStoreDemo.Features.Webstore.Collections;

public interface IWebstoreCollectionService
{
    Task AddProduct(long collectionId, long productId);
    Task RemoveProduct(long collectionId, long productId);

    Task<long> GetCollectId(long collectionId, long productId);
    Task<long> GetCollectionId(string title);

    Task<List<WebstoreProductModel>> GetAllProductsInCollection(long collectionId);
    Task<List<WebstoreProductModel>> Get50ProductsInCollection(long collectionId);
}