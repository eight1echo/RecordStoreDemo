using System.Text;
using RecordStoreDemo.External.Shopify;
using ShopifySharp;

namespace RecordStoreDemo.Features.Webstore.MetaFields;
public class WebstoreMetaFieldService : IWebstoreMetaFieldService
{
    private readonly IShopifyClientFactory _shopifyClient;

    public WebstoreMetaFieldService(IShopifyClientFactory shopifyClient)
    {
        _shopifyClient = shopifyClient;
    }

    public async Task<List<WebstoreMetaFieldModel>> GetProductMetaFields(long productId)
    {
        var client = await _shopifyClient.MetaFieldService();

        var response = await client.ListAsync(productId, "products");
        var existingMetaFields = new List<WebstoreMetaFieldModel>();

        if (response.Items.Any())
        {
            foreach (var item in response.Items)
            {
                existingMetaFields.Add(new WebstoreMetaFieldModel(item.Key, item.Value.ToString()!) { Id = (long)item.Id! });
            }
        }

        return existingMetaFields;
    }

    public async Task UpdateGenres(WebstoreProductModel product)
    {
        var client = await _shopifyClient.MetaFieldService();

        var firstValue = product.Genres.First();
        StringBuilder sbValues = new($"[\"{firstValue}\"]");

        product.Genres.Remove(firstValue);
        if (product.Genres.Any())
        {
            foreach (var value in product.Genres)
            {
                sbValues.Insert(1, $"\"{value}\", ");
            }
        }
        product.Genres.Add(firstValue);

        var val = sbValues.ToString();
        await client.CreateAsync(new MetaField()
        {
            Key = "music_genres",
            Namespace = "custom",
            Type = "list.single_line_text_field",
            Value = val
        }, product.Id, "products");
    }

    public async Task UpdateStyles(WebstoreProductModel product)
    {
        var client = await _shopifyClient.MetaFieldService();

        var firstValue = product.Styles.First();
        StringBuilder sbValues = new($"[\"{firstValue}\"]");

        product.Styles.Remove(firstValue);
        if (product.Styles.Count > 0)
        {
            foreach (var value in product.Styles)
            {
                sbValues.Insert(1, $"\"{value}\", ");
            }
        }
        product.Styles.Add(firstValue);

        var val = sbValues.ToString();
        await client.CreateAsync(new MetaField()
        {
            Key = "music_styles",
            Namespace = "custom",
            Type = "list.single_line_text_field",
            Value = val
        }, product.Id, "products");
    }

    public async Task UpdateTags(WebstoreProductModel product)
    {
        var client = await _shopifyClient.ProductService();

        var updatedProduct = new ShopifySharp.Product()
        {
            ProductType = product.ProductType,
            PublishedAt = DateTimeOffset.Now,
            PublishedScope = "web",
            Tags = product.Tags.ToCommaSeparatedFromList()
        };

        await client.UpdateAsync(product.Id, updatedProduct);
    }
}