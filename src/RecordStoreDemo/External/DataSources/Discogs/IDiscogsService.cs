namespace RecordStoreDemo.External.DataSources.Discogs;

public interface IDiscogsService
{
    Task<List<ImageModel>> ImageQuery(WebQuery query);
}