using RecordStoreDemo.External.Azure;
using ShopifySharp;

namespace RecordStoreDemo.External.Shopify;
public class ShopifyClientFactory : IShopifyClientFactory
{
    private readonly AzureKeyVaultService _keyVault;

    public ShopifyClientFactory(AzureKeyVaultService keyVault)
    {
        _keyVault = keyVault;
    }

    public async Task<CollectService> CollectService()
    {
        var credentials = await _keyVault.AuthenticateShopify();

        return new CollectService(credentials.StoreUrl, credentials.Token);
    }

    public async Task<CustomCollectionService> CustomCollectionService()
    {
        var credentials = await _keyVault.AuthenticateShopify();

        return new CustomCollectionService(credentials.StoreUrl, credentials.Token);
    }

    public async Task<SmartCollectionService> SmartCollectionService()
    {
        var credentials = await _keyVault.AuthenticateShopify();

        return new SmartCollectionService(credentials.StoreUrl, credentials.Token);
    }

    public async Task<MetaFieldService> MetaFieldService()
    {
        var credentials = await _keyVault.AuthenticateShopify();

        return new MetaFieldService(credentials.StoreUrl, credentials.Token);
    }

    public async Task<ProductService> ProductService()
    {
        var credentials = await _keyVault.AuthenticateShopify();

        return new ProductService(credentials.StoreUrl, credentials.Token);
    }

    public async Task<ProductVariantService> ProductVariantService()
    {
        var credentials = await _keyVault.AuthenticateShopify();

        return new ProductVariantService(credentials.StoreUrl, credentials.Token);
    }
}