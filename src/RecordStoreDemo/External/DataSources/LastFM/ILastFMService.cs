namespace RecordStoreDemo.External.DataSources.LastFM;

public interface ILastFMService
{
    Task<ImageModel?> ImageQuery(WebQuery query);
    Task<List<string>> TagQuery(WebQuery query);
}