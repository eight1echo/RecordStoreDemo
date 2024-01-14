namespace RecordStoreDemo.External.DataSources.MusicBrainz;

public interface IMusicBrainzService
{
    Task<List<string>> GenreQuery(WebQuery query);
}