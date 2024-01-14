using MetaBrainz.MusicBrainz;

namespace RecordStoreDemo.External.DataSources.MusicBrainz;
public class MusicBrainzService : IMusicBrainzService
{
    public async Task<List<string>> GenreQuery(WebQuery query)
    {
        var genres = new List<string>();
        var q = new Query("Test", "1.0", "mailto:a.ols@outlook.com");

        var response = await q.FindReleaseGroupsAsync($"artist:{query.Artist} AND release:{query.Title}");

        if (response.Results.Any())
        {
            var release = response.Results[0];

            if (release.Item.Tags is not null && release.Item.Tags.Any())
            {
                foreach (var tag in release.Item.Tags)
                {
                    genres.Add(tag.Name);
                }
            }
        }

        return genres;
    }
}