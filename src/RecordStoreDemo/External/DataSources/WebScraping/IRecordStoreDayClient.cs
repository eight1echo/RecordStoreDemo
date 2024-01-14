namespace RecordStoreDemo.External.DataSources.WebScraping;

public interface IRecordStoreDayClient
{
    Task<ImageModel?> ImageQuery(WebQuery query);
}