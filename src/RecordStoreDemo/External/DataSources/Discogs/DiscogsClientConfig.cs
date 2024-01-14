using ParkSquare.Discogs;

namespace RecordStoreDemo.External.DataSources.Discogs;
public class DiscogsClientConfig : IClientConfig
{
    public string? AuthToken { get; set; }

    public string? BaseUrl => "https://api.discogs.com";
}