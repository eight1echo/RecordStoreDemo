
namespace RecordStoreDemo.Persistence.Repositories;

public interface IInventoryProductRepository : IBaseRepository<InventoryProduct>
{
    Task<InventoryProduct> GetProduct(Guid productId);
    Task<InventoryProduct> GetProductByUPC(string upc);
    Task<List<InventoryProduct>> GetProducts(Guid[] productIds);
}