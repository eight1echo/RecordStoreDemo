using ShopifySharp;

namespace RecordStoreDemo.External.Shopify;

public interface IShopifyClientFactory
{
    Task<CollectService> CollectService();
    Task<CustomCollectionService> CustomCollectionService();
    Task<MetaFieldService> MetaFieldService();
    Task<ProductService> ProductService();
    Task<ProductVariantService> ProductVariantService();
    Task<SmartCollectionService> SmartCollectionService();
}