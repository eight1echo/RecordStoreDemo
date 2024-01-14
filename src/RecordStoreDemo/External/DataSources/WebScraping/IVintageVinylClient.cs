namespace RecordStoreDemo.External.DataSources.WebScraping;

public interface IVintageVinylClient
{
    Task<ImageModel?> ImageQuery(WebQuery query);
}