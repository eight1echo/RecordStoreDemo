using RecordStoreDemo.Features.Inventory.Products.Commands.CreateInventoryProduct;
using RecordStoreDemo.Features.Inventory.Products.Commands.UpdateProductDetails;
using RecordStoreDemo.Features.Inventory.Products.Commands.UpdateProductOnHand;
using RecordStoreDemo.Features.Inventory.Products.Commands.UpdateProductPrice;

namespace RecordStoreDemo.Features.Inventory.Products;

public interface IInventoryProductService
{
    Task<InventoryProductModel> CreateInventoryProduct(CreateInventoryProductRequest request);
    Task<InventoryProductModel?> FindInventoryProductByUPC(string upc);
    Task<List<InventoryProductModel>> FindInventoryProducts(ProductQueryRequest request);
    Task<List<OnHandHistoryModel>> GetProductOnHandHistory(Guid id);
    Task<List<PriceHistoryModel>> GetProductPriceHistory(Guid id);
    Task UpdateProductDetails(UpdateProductDetailsRequest request);
    Task<OnHandHistoryModel> UpdateProductOnHand(UpdateProductOnHandRequest request);
    Task<PriceHistoryModel> UpdateProductPrice(UpdateProductPriceRequest request);
}