using RecordStoreDemo.External.Shopify;
using ShopifySharp;
using ShopifySharp.Filters;

namespace RecordStoreDemo.Features.Webstore.Collections;
public class WebstoreCollectionService : IWebstoreCollectionService
{
    private readonly IShopifyClientFactory _shopifyClient;

    public WebstoreCollectionService(IShopifyClientFactory shopifyClient)
    {
        _shopifyClient = shopifyClient;
    }

    public async Task<long> GetCollectId(long collectionId, long productId)
    {
        var client = await _shopifyClient.CollectService();

        var response = await client.ListAsync(new CollectListFilter() { CollectionId = collectionId, ProductId = productId });

        if (response.Items.Any())
        {
            var collectId = (long)response.Items.First().Id!;

            return collectId;
        }

        return 0;
    }

    public async Task<long> GetCollectionId(string title)
    {
        var customClient = await _shopifyClient.CustomCollectionService();
        var smartClient = await _shopifyClient.SmartCollectionService();

        var customCollections = await customClient.ListAsync(new CustomCollectionListFilter { Title = title });

        if (customCollections.Items.Any())
        {
            var collectionId = (long)customCollections.Items.First().Id!;

            return collectionId;
        }

        var smartCollections = await smartClient.ListAsync(new SmartCollectionListFilter { Title = title });

        if (smartCollections.Items.Any())
        {
            var collectionId = (long)smartCollections.Items.First().Id!;

            return collectionId;
        }

        return 0;
    }

    public async Task AddProduct(long collectionId, long productId)
    {
        var client = await _shopifyClient.CollectService();

        await client.CreateAsync(new Collect() { CollectionId = collectionId, ProductId = productId });
    }

    public async Task RemoveProduct(long collectionId, long productId)
    {
        var client = await _shopifyClient.CollectService();

        var collectId = await GetCollectId(collectionId, productId);

        await client.DeleteAsync(collectId);
    }

    public async Task<List<WebstoreProductModel>> GetAllProductsInCollection(long collectionId)
    {
        var client = await _shopifyClient.ProductService();

        var response = await client.ListAsync(new ProductListFilter { CollectionId = collectionId });
        var shopifyProducts = response.Items.ToArray();

        var webstoreProducts = new List<WebstoreProductModel>();

        for (var i = 0; i < shopifyProducts.Length; i++)
        {
            var shopifyProduct = shopifyProducts[i];
            var variant = shopifyProduct.Variants.First();

            webstoreProducts.Add(new WebstoreProductModel()
            {
                Id = (long)shopifyProduct.Id!,
                ProductType = shopifyProduct.ProductType,
                PublishedAt = shopifyProduct.PublishedAt,
                Status = shopifyProduct.Status,
                Tags = shopifyProduct.Tags.ToListFromCommaSeparated(),
                Title = shopifyProduct.Title,

                Variant = new WebstoreProductVariantModel()
                {
                    Id = (long)variant.Id!,
                    Barcode = variant.Barcode,
                    Weight = (decimal)variant.Weight!
                }
            });

            if (i == shopifyProducts.Length - 1 && response.HasNextPage)
            {
                i = -1;
                response = await client.ListAsync(response.GetNextPageFilter());
                shopifyProducts = response.Items.ToArray();
            }
        }

        return webstoreProducts;
    }

    public async Task<List<WebstoreProductModel>> Get50ProductsInCollection(long collectionId)
    {
        var client = await _shopifyClient.ProductService();

        var response = await client.ListAsync(new ProductListFilter { CollectionId = collectionId });
        var shopifyProducts = response.Items.ToArray();

        var webstoreProducts = new List<WebstoreProductModel>();

        foreach (var product in shopifyProducts)
        {
            var variant = product.Variants.First();

            webstoreProducts.Add(new WebstoreProductModel()
            {
                Id = (long)product.Id!,
                ProductType = product.ProductType,
                PublishedAt = product.PublishedAt,
                Status = product.Status,
                Tags = product.Tags.ToListFromCommaSeparated(),
                Title = product.Title,

                Variant = new WebstoreProductVariantModel()
                {
                    Id = (long)variant.Id!,
                    Barcode = variant.Barcode,
                    Weight = (decimal)variant.Weight!
                }
            });
        }

        return webstoreProducts;
    }
}