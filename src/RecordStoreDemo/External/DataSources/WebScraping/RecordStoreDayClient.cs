using HtmlAgilityPack;

namespace RecordStoreDemo.External.DataSources.WebScraping;
public class RecordStoreDayClient : IRecordStoreDayClient
{
    private readonly HttpClient _httpClient;

    public RecordStoreDayClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://recordstoreday.com/UPC/");
    }
    public async Task<ImageModel?> ImageQuery(WebQuery query)
    {
        if (query == null) return null;

        var html = await _httpClient.GetStringAsync(query.UPC);

        HtmlDocument htmlDoc = new();
        htmlDoc.LoadHtml(html);

        var img = htmlDoc.DocumentNode.SelectSingleNode("/html/body/main/div/div/div[2]/div/div/div[1]/div[1]/article/div[1]/a/img");

        if (img is not null)
        {
            return new ImageModel(img.Attributes["src"].Value, WebQuerySource.WebScrape);
        }

        return null;
    }
}