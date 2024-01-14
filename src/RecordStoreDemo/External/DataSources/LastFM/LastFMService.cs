using IF.Lastfm.Core.Api;
using RecordStoreDemo.External.Azure;

namespace RecordStoreDemo.External.DataSources.LastFM;
public class LastFMService : ILastFMService
{
    private readonly AzureKeyVaultService _keyVault;

    public LastFMService(AzureKeyVaultService keyVault)
    {
        _keyVault = keyVault;
    }

    public async Task<ImageModel?> ImageQuery(WebQuery query)
    {
        if (query.Artist is not null && query.Title is not null)
        {
            var credentials = await _keyVault.AuthenticateLastFM();

            var client = new LastfmClient(credentials.ApiKey, credentials.ApiSecret);

            var response = await client.Album.GetInfoAsync(query.Artist, query.Title, autocorrect: true);

            var album = response.Content;

            if (album is null || album.Images.Largest is null)
            {
                return null;
            }

            return new ImageModel(album.Images.Largest.AbsoluteUri, WebQuerySource.LastFM);
        }

        return null;
    }

    public async Task<List<string>> TagQuery(WebQuery query)
    {
        var credentials = await _keyVault.AuthenticateLastFM();
        var client = new LastfmClient(credentials.ApiKey, credentials.ApiSecret);

        var response = await client.Artist.GetTopTagsAsync(query.Artist, autocorrect: true);

        var tags = response.Content.Take(10).Select(tag => tag.Name).ToList();

        return tags;
    }
}
