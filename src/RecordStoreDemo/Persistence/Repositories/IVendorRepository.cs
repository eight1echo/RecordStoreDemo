namespace RecordStoreDemo.Persistence.Repositories;

public interface IVendorRepository : IBaseRepository<Vendor>
{
    Task<CatalogProduct> GetCatalogProduct(Guid productId);
    Task<List<CatalogProduct>> ListCatalogProducts(Guid[] productIds);
    Task<Vendor> GetVendor(Guid vendorId);
    Task<Vendor> GetVendorWithProducts(Guid vendorId);
}