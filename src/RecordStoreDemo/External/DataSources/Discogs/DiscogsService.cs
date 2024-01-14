using ParkSquare.Discogs;
using RecordStoreDemo.External.Azure;

namespace RecordStoreDemo.External.DataSources.Discogs;
public class DiscogsService : IDiscogsService
{
    private readonly AzureKeyVaultService _keyVault;

    public DiscogsService(AzureKeyVaultService keyVault)
    {
        _keyVault = keyVault;
    }

    public async Task<List<ImageModel>> ImageQuery(WebQuery query)
    {
        var images = new List<ImageModel>();

        // Prioritize search by UPC, if none found search with Aritst & Title
        if (!string.IsNullOrEmpty(query.UPC))
        {
            var barcodeSearch = new SearchCriteria { Barcode = query.UPC };
            images.AddRange(await ExecuteSearch(barcodeSearch));
        }

        if (images.Count == 0)
        {
            var titleSearch = new SearchCriteria { Artist = query.Artist, Title = query.Title };
            images.AddRange(await ExecuteSearch(titleSearch));
        }

        return images;
    }

    private async Task<List<ImageModel>> ExecuteSearch(SearchCriteria searchCriteria)
    {
        var credentials = await _keyVault.AuthenticateDiscogs();

        var client = new DiscogsClient(
            new HttpClient(new HttpClientHandler()),
            new ApiQueryBuilder(new DiscogsClientConfig() { AuthToken = credentials.Token }));

        var result = await client.SearchAllAsync(searchCriteria);

        var images = new List<ImageModel>();
        foreach (var i in result.Results)
        {
            if (!i.CoverImage.Contains("spacer.gif"))
            {
                images.Add(new ImageModel(i.CoverImage, WebQuerySource.Discogs));
            }
        }

        return images;
    }
}