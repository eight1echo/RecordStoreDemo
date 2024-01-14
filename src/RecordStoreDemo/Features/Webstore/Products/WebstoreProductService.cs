using RecordStoreDemo.External.Shopify;
using ShopifySharp;
using ShopifySharp.Filters;

namespace RecordStoreDemo.Features.Webstore.Products;

public class WebstoreProductService : IWebstoreProductService
{
    private readonly IShopifyClientFactory _shopifyClient;
    private readonly IWebstoreMetaFieldService _shopifyMetaFields;

    public WebstoreProductService(IShopifyClientFactory shopifyClient, IWebstoreMetaFieldService shopifyMetaFields)
    {
        _shopifyClient = shopifyClient;
        _shopifyMetaFields = shopifyMetaFields;
    }

    public async Task<WebstoreProductModel?> GetProduct(string upc)
    {
        var client = await _shopifyClient.ProductService();

        var existingProducts = await client.ListAsync(new ProductListFilter { Handle = upc });

        if (existingProducts.Items.Any())
        {
            var shopifyProduct = existingProducts.Items.First();
            var variant = shopifyProduct.Variants.First();

            var product = new WebstoreProductModel
            {
                Id = (long)shopifyProduct.Id,
                PublishedAt = shopifyProduct.PublishedAt,
                ProductType = shopifyProduct.ProductType,
                Status = shopifyProduct.Status,
                Tags = shopifyProduct.Tags.ToListFromCommaSeparated(),
                Title = shopifyProduct.Title,

                Variant = new WebstoreProductVariantModel
                {
                    Barcode = variant.Barcode,
                    Price = (decimal)variant.Price,
                    SKU = variant.SKU,
                    Weight = (decimal)variant.Weight
                }
            };

            if (shopifyProduct.Images.Any())
            {
                product.ImagePath = shopifyProduct.Images.First().Src;
            }

            var metafields = await _shopifyMetaFields.GetProductMetaFields(product.Id);

            foreach (var metafield in metafields)
            {
                if (metafield.Key == "music_genres")
                {
                    product.Genres = metafield.Values;
                }
                if (metafield.Key == "music_styles")
                {
                    product.Styles = metafield.Values;
                }
            }

            return product;
        }

        return null;
    }

    public async Task<WebstoreProductModel> CreateDraftProduct(InventoryProductModel inventoryProduct)
    {
        var client = await _shopifyClient.ProductService();

        var shopifyProduct = new Product()
        {
            CreatedAt = DateTime.Now,
            Handle = inventoryProduct.UPC,
            Status = "draft",
            Title = $"{inventoryProduct.Artist}/{inventoryProduct.Title} [{inventoryProduct.Format}]",
            Vendor = "Test Store",
            ProductType = inventoryProduct.Format,
            PublishedAt = DateTime.Now,
            PublishedScope = "web",

            Variants = new List<ProductVariant>
            {
                new ProductVariant
                {
                    Barcode = inventoryProduct.UPC,
                    InventoryManagement = "shopify",
                    Price = inventoryProduct.Price,
                    SKU = inventoryProduct.UPC,
                    Weight = 0.5m,
                }
            }
        };

        shopifyProduct = await client.CreateAsync(shopifyProduct);

        var variant = shopifyProduct.Variants.First();

        var newProduct = new WebstoreProductModel()
        {
            Id = (long)shopifyProduct.Id,
            PublishedAt = shopifyProduct.PublishedAt,
            ProductType = shopifyProduct.ProductType,
            Status = shopifyProduct.Status,
            Title = shopifyProduct.Title,

            Variant = new WebstoreProductVariantModel
            {
                Barcode = variant.Barcode,
                Price = (decimal)variant.Price,
                SKU = variant.SKU,
                Weight = (decimal)variant.Weight
            }
        };

        return newProduct;
    }

    public async Task UpdateProduct(UpdateWebstoreProductRequest request)
    {
        var client = await _shopifyClient.ProductService();

        var updatedProduct = new Product()
        {
            PublishedAt = request.PublishedAt ?? DateTime.Now,
            PublishedScope = "web",
            Status = request.Status,
            Title = request.Title,
            Variants = new List<ProductVariant>
            {
                new ProductVariant
                {
                    Barcode = request.UPC,
                    Price = request.Price,
                    SKU = request.UPC,
                    Weight = request.Weight
                }
            },
        };

        await client.UpdateAsync(request.ProductId, updatedProduct);
    }
}