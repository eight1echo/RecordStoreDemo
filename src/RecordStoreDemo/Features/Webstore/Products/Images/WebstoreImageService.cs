using RecordStoreDemo.External.DataSources.Discogs;
using RecordStoreDemo.External.DataSources.LastFM;
using RecordStoreDemo.External.DataSources.WebScraping;
using RecordStoreDemo.External.DataSources;
using ShopifySharp;
using RecordStoreDemo.External.Shopify;

namespace RecordStoreDemo.Features.Webstore.Products.Images;

public class WebstoreImageService : IWebstoreImageService
{
    private readonly IDiscogsService _discogs;
    private readonly ILastFMService _lastfm;
    private readonly IRecordStoreDayClient _recordStoreDayClient;
    private readonly IVintageVinylClient _vintageVinylClient;
    private readonly IShopifyClientFactory _shopifyClient;

    public WebstoreImageService(IDiscogsService discogs, ILastFMService lastfm, IRecordStoreDayClient recordStoreDayClient, IVintageVinylClient vintageVinylClient, IShopifyClientFactory shopifyClient)
    {
        _discogs = discogs;
        _lastfm = lastfm;
        _recordStoreDayClient = recordStoreDayClient;
        _vintageVinylClient = vintageVinylClient;
        _shopifyClient = shopifyClient;
    }

    public async Task<List<ImageModel>> FindImages(WebQuery query)
    {
        var images = new List<ImageModel>();

        switch (query.Source)
        {
            case WebQuerySource.All:

                var lastfmResult = await _lastfm.ImageQuery(query);
                if (lastfmResult is not null)
                    images.Add(lastfmResult);

                var vvResult = await _vintageVinylClient.ImageQuery(query);
                if (vvResult is not null)
                    images.Add(vvResult);

                var rsdResult = await _recordStoreDayClient.ImageQuery(query);
                if (rsdResult is not null)
                    images.Add(rsdResult);

                var discogsResult = await _discogs.ImageQuery(query);
                if (discogsResult.Count > 0)
                    images.AddRange(discogsResult);

                break;

            case WebQuerySource.LastFM:

                lastfmResult = await _lastfm.ImageQuery(query);
                if (lastfmResult is not null)
                    images.Add(lastfmResult);

                break;

            case WebQuerySource.Discogs:

                discogsResult = await _discogs.ImageQuery(query);
                if (discogsResult.Any())
                    images.AddRange(discogsResult);

                break;

            case WebQuerySource.WebScrape:

                vvResult = await _vintageVinylClient.ImageQuery(query);
                if (vvResult is not null)
                    images.Add(vvResult);

                rsdResult = await _recordStoreDayClient.ImageQuery(query);
                if (rsdResult is not null)
                    images.Add(rsdResult);

                break;
        }

        return images;
    }

    public async Task UpdateImage(UpdateWebstoreImageRequest request)
    {
        var client = await _shopifyClient.ProductService();

        var updatedProduct = new Product()
        {
            Images = new List<ProductImage> { new ProductImage { Src = request.ImagePath } }
        };

        await client.UpdateAsync(request.ProductId, updatedProduct);
    }
}