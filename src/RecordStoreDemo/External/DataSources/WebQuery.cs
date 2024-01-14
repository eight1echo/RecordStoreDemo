namespace RecordStoreDemo.External.DataSources;

public class WebQuery
{
    public WebQuery(string webstoreTitle)
    {
        if (webstoreTitle.Contains('/'))
        {
            var split = webstoreTitle.Split('/');

            var artist = split[0];

            if (artist.Contains(','))
            {
                var artistSplit = artist.Split(',');
                artist = artistSplit[1].TrimStart() + " " + artistSplit[0];
            }

            var splitTitle = split[1].Split('[');
            var title = splitTitle[0];

            if (title.Contains('('))
            {
                splitTitle = title.Split('(');
                title = splitTitle[0].TrimEnd();
            }

            if (title.Contains(':'))
            {
                splitTitle = title.Split(':');
                title = splitTitle[0].TrimEnd();
            }

            Artist = artist;
            Title = title;
        }
        else
        {
            Title = webstoreTitle;
        }
    }

    public string? Artist { get; set; }
    public string? Title { get; set; }
    public string? UPC { get; set; }
    public WebQuerySource Source { get; set; } = WebQuerySource.All;
}
