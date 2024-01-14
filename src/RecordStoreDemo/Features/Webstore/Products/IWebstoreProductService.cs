namespace RecordStoreDemo.Features.Webstore.Products;

public interface IWebstoreProductService
{
    Task<WebstoreProductModel> CreateDraftProduct(InventoryProductModel inventoryProduct);
    Task<WebstoreProductModel?> GetProduct(string upc);
    Task UpdateProduct(UpdateWebstoreProductRequest request);
}