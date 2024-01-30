using RecordStoreDemo.Features.Inventory.Products.Commands.CreateInventoryProduct;
using RecordStoreDemo.Features.Inventory.Products.Commands.UpdateProductDetails;
using RecordStoreDemo.Features.Inventory.Products.Commands.UpdateProductOnHand;
using RecordStoreDemo.Features.Inventory.Products.Commands.UpdateProductPrice;

namespace RecordStoreDemo.Features.Inventory.Products;

public interface IInventoryProductService
{
    Task<ServiceResult<InventoryProductModel>> CreateInventoryProduct(CreateInventoryProductRequest request);
    Task<ServiceResult<InventoryProductModel>> FindInventoryProductByUPC(string upc);
    Task<ServiceResult<List<InventoryProductModel>>> FindInventoryProducts(ProductQueryRequest request);
    Task<ServiceResult<List<OnHandHistoryModel>>> GetProductOnHandHistory(Guid id);
    Task<ServiceResult<List<PriceHistoryModel>>> GetProductPriceHistory(Guid id);
    Task<ServiceResult<InventoryProductModel>> UpdateProductDetails(UpdateProductDetailsRequest request);
    Task<ServiceResult<OnHandHistoryModel>> UpdateProductOnHand(UpdateProductOnHandRequest request);
    Task<ServiceResult<PriceHistoryModel>> UpdateProductPrice(UpdateProductPriceRequest request);
}